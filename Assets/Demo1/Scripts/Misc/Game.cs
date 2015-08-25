using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.Xml.Linq;

public class Game{

	public Collection collection;
	public CollectionStatus collectionStatus; 
	public Artefact currentArtefact;
	public bool artefactJustCollected;

	public Game(String XMLContent){
		collection = new Collection (XMLContent);
		collectionStatus = new CollectionStatus(collection.getTotal());
		currentArtefact = null;
		artefactJustCollected = false;
	}
	
	public Collection getCollection(){
		return collection;
	}

	public CollectionStatus getCollectionStatus(){
		return collectionStatus;
	}

	public Artefact getCurrentArtefact(){
		return  currentArtefact;
	}
	
	public void setCurrentArtefact(Artefact currentArtefact){
		this.currentArtefact = currentArtefact;		
	}

	public bool isArtefactJustCollected(){
		return  artefactJustCollected;
	}
	
	public void setArtefactJustCollected(bool artefactJustCollected){
		this.artefactJustCollected = artefactJustCollected;		
	}
	
	public void resetGame(){
		collectionStatus = new CollectionStatus(collection.getTotal());
		currentArtefact = null;
		artefactJustCollected = false;
	}

	public void updateGame(Collection collection, CollectionStatus collectionStatus, Artefact currentArtefact, bool artefactJustCollected){
		if(collection != null)
			this.collection = collection;
		if(collectionStatus!=null)
			this.collectionStatus = collectionStatus;
		if(currentArtefact!=null)
			this.currentArtefact = currentArtefact;
		if(artefactJustCollected!=null)
			this.artefactJustCollected = artefactJustCollected;
	}
}





