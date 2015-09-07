using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuButtonsManager : MonoBehaviour {

	private Game game;
	
	void Start () {	
		game = SharedInfo.getCurrGame ();
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

	public void continueLoadLevel(){
		bool won = game.getCollection ().getTotal () == game.getCollectionStatus ().getTotalCollected ();
		if(won)
			Application.LoadLevel ("Collection");
		else
			Application.LoadLevel ("Loader");

	}

	public void loadLevel(string levelToLoad){
		Application.LoadLevel (levelToLoad);
	}
}
