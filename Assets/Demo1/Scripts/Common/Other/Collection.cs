﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

public class Collection : IEnumerable<Artefact>{

	private List<Artefact> collection;

	public Collection(){
		collection = new List<Artefact> ();
	}

	public Collection (String XMLContent){

		// TODO manage if number are not ordered
		collection = new List<Artefact> ();
		XDocument xdoc = XDocument.Parse(XMLContent);
		var queryResult = from artefact in xdoc.Descendants("artefact")
		select new { 
			id = artefact.Attribute("id"),
			artefactNames = artefact.Descendants("name"),
			artefactStories = artefact.Descendants("story"),
			artefactClues = artefact.Descendants("clue")
		};
		foreach (var artefact in queryResult){
			addArtefact(new Artefact(
				Int32.Parse(artefact.id.Value), artefact.artefactNames.FirstOrDefault().Value, artefact.artefactStories.FirstOrDefault().Value, artefact.artefactClues.FirstOrDefault().Value));	
		}
	}

	public void addArtefact(Artefact artefact){
		collection.Add (artefact);
	}

	public void addArtefact(int id, string name, string story, string clue){
		collection.Add (new Artefact (id, name, story, clue));
	}

	public Artefact getArtefactByName(string artefactName){
		return collection.Find((x => x.getName() == artefactName));
	}

	public Artefact getArtefactById(int artefactId){
		return collection.Find((x => x.getId() == artefactId));
	}
	
	public int getTotal(){
		return collection.Count;
	}

	public IEnumerator<Artefact> GetEnumerator()
	{
		for (int index = 0; index < getTotal(); index++)
			yield return collection[index];
	}
	
	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}


public class Artefact{

	private int id;
	private string name;
	private string story;
	private string clue;

	public Artefact(){
		this.id = -1;
		this.name = null;
		this.story = null;
		this.clue = null;
	}

	public Artefact(int id, string name, string story, string clue){
		this.id = id;
		this.name = name;
		this.story = story;
		this.clue = clue;
	}

	public int getId(){
		return id;
	}

	public string getName(){
		return name;
	}

	public string getStory(){
		return story;
	}

	public string getClue(){
		return clue;
	}

	public override bool Equals(System.Object obj)
	{
		if (obj == null)
			return false;
		
		Artefact artefact = obj as Artefact;
		if ((System.Object)artefact == null)
			return false;
		return (getName() == artefact.getName()) && (getId() == artefact.getId());
	}
	
	public bool Equals(Artefact artefact)
	{
		if ((object)artefact == null)	
			return false;
		return (getName() == artefact.getName()) && (getId() == artefact.getId());
	}

	public override int GetHashCode()
	{
		return getId ().GetHashCode () + getName ().GetHashCode();
	}

} 




