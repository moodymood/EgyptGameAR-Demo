using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnButtonClick : MonoBehaviour {
	
	//public string artefactName = "ArtefactName";
	//public int artefactId;
	private string levelToLoad = "ArtefactDetail";

	
	void Start () {
	}
	
	void Update () {
	}
	
	public void loadLevel(int artefactId){
		Artefact selectedArtefact = SharedInfo.getCurrGame ().getCollection ().getArtefactById (artefactId);
		SharedInfo.getCurrGame().setCurrentArtefact(selectedArtefact);
		Application.LoadLevel(levelToLoad);
	}

	public void loadLevel(string levelToLoad){
		Application.LoadLevel(levelToLoad);
	}

	
	public void IntroEndloadLevel(){
		// Not finished
		if (SharedInfo.getCurrGame().getCollection ().getTotal () != SharedInfo.getCurrGame().getCollectionStatus ().getTotalCollected ())
			Application.LoadLevel ("Clue");
		else
			Application.LoadLevel ("Menu");
	}



	//void OnGUI () {
		//GUIStyle guiStyle = new GUIStyle();
		//guiStyle.fontSize = 50; //change the font size
		//GUI.Label(new Rect(20, 220,600,200), "currArt" + game.getCurrentArtefact().getName(), guiStyle);
	//}
	
}
