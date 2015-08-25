using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class CollectionStatus{
	
	private Dictionary<int, bool> collectionStatus;
	
	public CollectionStatus(int maxNumber){
		collectionStatus = new Dictionary<int, bool> (maxNumber);
	}
	
	public void setAsCollected(Artefact artefact){
		collectionStatus.Add(artefact.getId(), true);
	}
	
	public bool isCollected(Artefact artefact){
		bool isCollected;
		collectionStatus.TryGetValue (artefact.getId (), out isCollected);
		return isCollected;
	}
	
	public bool isFinished(){
		// Finished if there is not even one false
		return !collectionStatus.ContainsValue(false);
	}
	
	public int getNextToCollect(){
		return getTotalCollected ();
	}
	
	public int getTotalCollected(){
		int count = 0;
		foreach (var key in collectionStatus.Keys)
			if (collectionStatus[key])
				count++;
		return count;
	}
	
	
}