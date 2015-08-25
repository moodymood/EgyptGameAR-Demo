using UnityEngine;
using System.Collections;

public class AppOnBackCustom : MonoBehaviour {

	private Game game;
	private string levelToGo;
	private bool isJustCollected;
	private bool won;

	void Start () {	
		game = SharedInfo.getCurrGame ();
		won = (game.getCollection ().getTotal () == game.getCollectionStatus ().getTotalCollected ());

		isJustCollected = game.isArtefactJustCollected ();
		if(isJustCollected && !won){
			levelToGo = "CameraFinder";
		}else{
			levelToGo = "Collection";
		}
	}
	
	void Update (){
		if (Input.GetKey (KeyCode.Escape)) {
			game.setArtefactJustCollected(false);
			Application.LoadLevel(levelToGo);
		}
	}

	public void loadLevel(){
		game.setArtefactJustCollected(false);
		Application.LoadLevel(levelToGo);
	}

	void OnGUI () {
		//GUIStyle guiStyle = new GUIStyle();
		//guiStyle.fontSize = 50; //change the font size
		//GUI.Label(new Rect(20, 220,600,200), "is just collected" + game.isArtefactJustCollected(), guiStyle);
	}
}
