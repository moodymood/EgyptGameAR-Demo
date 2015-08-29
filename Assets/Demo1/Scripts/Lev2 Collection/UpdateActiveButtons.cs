using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateActiveButtons : MonoBehaviour {
	
	public Game game;
	private string resSpritesPath = "Sprites/CollectionPreview/";

	// Use this for initialization
	void Start () {
		game = SharedInfo.getCurrGame ();

		updateArtefactButtons();
		updateWonButton ();
	}
	
	// Update is called once per frame
	void Update () {
		//updateButtons ();
		//Debug.Log ("get by id" + game.getCollection ().getArtefactById (0).getName());
		//Debug.Log ("get by id" + game.getCollection ().getArtefactById (1).getName());
		//Debug.Log ("get by id" + game.getCollection ().getArtefactById (2).getName());

	}

	// Supports a list of button in the scene, where a button active can be clicked to access the infromation
	// of a specific artefact. 
	// There has to be a mapping IdArtefact -> buttonNames
	// It then load information about artefact into the botton
	// Needs pictures of artefact in the Resource/Sprite/CollectionPreview folder
	
	public void updateArtefactButtons(){

		foreach (Artefact artefact in game.getCollection ()) {
			string buttonName = "Artefact" + artefact.getId () + "Button";
			string imageName = "Artefact" + artefact.getId () + "Image";
			string imageFileName = resSpritesPath + "Unknown";

			bool isInteractable = false;
			string artefactName = "";

			if (game.getCollectionStatus ().isCollected (artefact)) {
				isInteractable = true;
				artefactName = artefact.getName();
				imageFileName = resSpritesPath + artefact.getName ();
			}

			GameObject.Find (buttonName).GetComponent<Button> ().interactable = isInteractable;
			GameObject.Find (buttonName).GetComponentInChildren<Text> ().text = artefactName;
			GameObject.Find (imageName).GetComponent<Image> ().sprite = Resources.Load<Sprite>(imageFileName);
		}
		
	}

	public void updateWonButton(){

		bool won = (game.getCollection ().getTotal () == game.getCollectionStatus ().getTotalCollected ());
		bool isInteractable = false;
		string wonText = "Empty";
		string wonImage = "Unknown";

		if (!won) {
			isInteractable = false;
			wonText = "";
			wonImage = "";
			wonImage = "Unknown";
		} else {
			isInteractable = true;
			wonText = "You Won The Game!";
			wonImage = "Cup";
		}

		GameObject.Find ("WonButton").GetComponent<Button> ().interactable = isInteractable;
		GameObject.Find ("WonButton").GetComponentInChildren<Text> ().text = wonText;
		GameObject.Find ("WonImage").GetComponent<Image> ().sprite = Resources.Load<Sprite>(resSpritesPath + wonImage);
	}

	void OnGUI () {

		GUIStyle guiStyle = new GUIStyle();
		guiStyle.fontSize = 50; //change the font size
//		GUI.Label(new Rect(20, 60,600,200), "won" + won, guiStyle);

	}
	

	
}


/*
 *  Old versione
			 * 
			string buttonName = "Artefact" + artefact.getId () + "Button";
			GameObject buttonObject = GameObject.Find (buttonName);
			if (!game.getCollectionStatus ().isCollected (artefact)) {
				Debug.Log (artefact.getName () + "set inactive");
				((Button)buttonObject.GetComponent ("Button")).interactable = false;
				//gameObject.Find("Artefact"+artefact.getId()).GetComponent<Button>().interactable = false;
				GameObject.Find (buttonName).GetComponentInChildren<Text> ().text = artefact.getName ();
			} else {
				((Button)buttonObject.GetComponent ("Button")).interactable = true;
				GameObject.Find (buttonName).GetComponentInChildren<Text> ().text = "";
				Debug.Log (artefact.getName () + "set active");
			}
*/
