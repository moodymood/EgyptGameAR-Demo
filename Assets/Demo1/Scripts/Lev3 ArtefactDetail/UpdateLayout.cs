using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateLayout : MonoBehaviour {

	private Game game;
	
	private bool buttonClicked = false;
	private bool orientationChanged = false;
	private bool fistTimeLoaded = true;

	private string lastOrientation;

	private string resSpritesPath = "Sprites/Layout/down";

	// Use this for initialization
	void Start () {
		game = SharedInfo.getCurrGame ();
		lastOrientation = getDeviceOrientation ();

		// Everytime the screen is loaded, unless it is the time when the artefact has just been collected, keep the panel down.
		if (!game.isArtefactJustCollected () && isPanelUp ())
			buttonClicked = true; // Simulate the click button to move the button down
	}
	
	// Update is called once per frame
	void Update () {

		updateOrientationChanged ();

		float height = GameObject.Find ("ArtefactStoryPanel").GetComponent<RectTransform> ().rect.height;
		Vector2 pos = GameObject.Find ("ArtefactStoryPanel").GetComponent<RectTransform> ().transform.position;
		Vector2 newPos = new Vector2 (pos.x, pos.y);

		// Invert
		if (buttonClicked) {
			
			if (isPanelUp()){
				newPos.y = pos.y - height;
				resSpritesPath = "Sprites/Layout/up";

			}
			else{
				newPos.y = pos.y + height;
				resSpritesPath = "Sprites/Layout/down";

			}
			
			buttonClicked = false;
		} 
		
		// Adapct
		if (orientationChanged) {
			
			if (isPanelUp())
				newPos.y = height / 2;
			else
				newPos.y = - height / 2;
			
			orientationChanged = false;
		} 

		GameObject.Find ("ArtefactStoryPanel").GetComponent<RectTransform> ().transform.position = newPos;
		GameObject.Find ("DetailButton").GetComponentsInChildren<Image> ()[1].sprite = Resources.Load<Sprite>(resSpritesPath);


	}


	// need to stay awake to save panelUp value
	//void Awake() {	
	//	DontDestroyOnLoad(this);	
	//} 

	public void updateOrientationChanged(){
		
		string currentOrientation = getDeviceOrientation ();
		if (lastOrientation != currentOrientation) {
			lastOrientation = currentOrientation;
			orientationChanged = true;
		} else
			orientationChanged = false;
	}


	
	public void setButtonClicked(){
		buttonClicked = true;
	}
	
	
	public string getDeviceOrientation(){
		if (Screen.height > Screen.width) 
			return "portrait";
		else
			return "landscape";	
	}

	public bool isPanelUp(){
		if (GameObject.Find ("ArtefactStoryPanel").GetComponent<RectTransform> ().transform.position.y > 0)
			return true;
		else
			return false;
	}

	void OnGUI(){
//		GUIStyle guiStyle = new GUIStyle();
//		guiStyle.fontSize = 50; //change the font size
//		GUI.Label (new Rect (20, 60, 400, 400), "lastOrientation" + lastOrientation, guiStyle);

	}
}
