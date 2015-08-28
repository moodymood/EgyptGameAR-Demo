using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuButtonsManager : MonoBehaviour {
	
	void Start () {	
	
	}
	
	void Update () {	
	}

	public void resetGame(){
		SharedInfo.getCurrGame().resetGame ();
		//Application.LoadLevel (levelToLoad);
	}

	public void quitGame(){
		Application.Quit ();
	}

	public void loadLevel(string levelToLoad){
		Application.LoadLevel (levelToLoad);
	}
}
