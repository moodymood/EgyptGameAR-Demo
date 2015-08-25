using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateLabelText : MonoBehaviour {

	// Update the label text identified with the labelToUpdate name
	// with the function inside Update()

	private Game game;


	void Start () {
		game = SharedInfo.getCurrGame ();		
	}
	
	void Update () {
		GameObject.Find ("BagPanel").GetComponentInChildren<Text> ().text = 
			game.getCollectionStatus().getTotalCollected () + "/" + game.getCollection().getTotal ();
	}

	void OnGUI(){
	//	GUIStyle guiStyle = new GUIStyle();
	//	guiStyle.fontSize = 50; //change the font size
	//	GUI.Label (new Rect (20, 60, 400, 400), "lastOrientation" + lastOrientation, guiStyle);
	}
}
