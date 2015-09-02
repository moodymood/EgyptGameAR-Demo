using UnityEngine;
using System.Collections;

public static class SharedInfo {
	public static Game getCurrGame(){
		return GameObject.Find ("InitSceneManager").GetComponent<GameInit> ().currentGame;
	}

	public static SceneStatus getSceneStatus(){
		return GameObject.Find ("InitSceneManager").GetComponent<GameInit> ().currentSceneStatus;
	}
	
}


