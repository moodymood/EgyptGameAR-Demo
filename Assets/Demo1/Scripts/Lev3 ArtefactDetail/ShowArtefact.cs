using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowArtefact : MonoBehaviour {

	public Game game;
	

	void Start () {

		game = SharedInfo.getCurrGame ();

		// hide all artefact which are not the current one
		updateActiveArtefact ();

		// set the content for the current artefact
		updateStoryPanelContent ();


	}

	void Update(){

	}

	
	public void updateActiveArtefact(){
		Collection collection = game.getCollection ();
		Artefact currentArtefact = game.getCurrentArtefact ();
		foreach (Artefact artefact in collection) {
			GameObject artefactObject = GameObject.Find (artefact.getName ());
			//TODO implement equal for artfat
			if (artefact.getName() != currentArtefact.getName())
				artefactObject.SetActive (false);
			else{
				artefactObject.SetActive (true);
			}
		}
	}

	public void updateStoryPanelContent(){
		GameObject.Find("StoryContentText").GetComponentInChildren<Text>().text = game.getCurrentArtefact().getStory();
		GameObject.Find ("DetailButton").GetComponentInChildren<Text> ().text = game.getCurrentArtefact().getName() + " Details"; 
	}

	void OnGUI () {
//		GUIStyle guiStyle = new GUIStyle();
//		guiStyle.fontSize = 50; //change the font size
//		GUI.Label(new Rect(20, 499,600,200), "currArt" + game.getCurrentArtefact().getName(), guiStyle);
	}

}
