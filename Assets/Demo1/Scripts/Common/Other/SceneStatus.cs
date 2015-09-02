using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneStatus {

	Dictionary<string, bool> sceneStatus;

	public SceneStatus(params string[] levelNames){
		sceneStatus = new Dictionary<string, bool> ();
		foreach (string s in levelNames) {
			sceneStatus.Add(s, false);
		}
	}

	public bool isVisited(string levelName){
		return sceneStatus [levelName];
	}

	public bool setVisited(string levelName){
		return sceneStatus [levelName] = true;
	}

	public bool setUnvisited(string levelName){
		return sceneStatus [levelName] = false;
	}

	
}
