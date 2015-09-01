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
			if(game.getCurrentArtefact().getId() == 0) // Only for Anubis
				SharedInfo.getSceneStatus().setUnvisited ("AfterCollection");
		}else{
			levelToGo = "Collection";
		}
	}

	public void setPanelActive(){
		Component[] infoPanels = GameObject.Find("InfoPanels").GetComponentsInChildren( typeof(Transform), true );
		foreach(Component temp in infoPanels){
			if (temp.name == "InfoPanel-AfterCollection"){
				temp.gameObject.SetActive(true);
			}
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
