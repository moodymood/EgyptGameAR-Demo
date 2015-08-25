using UnityEngine;
using System.Collections;

public static class SharedInfo {
	public static Game getCurrGame(){
		return GameObject.Find ("IntroductionSceneManager").GetComponent<GameInit> ().currentGame;
	}
	
}


