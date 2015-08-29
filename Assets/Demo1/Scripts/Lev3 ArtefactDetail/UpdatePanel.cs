using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdatePanel : MonoBehaviour {

	private Game game;
	
	private bool buttonClicked = false;
	private bool orientationChanged = false;

	private string lastOrientation;

	private Sprite currSprite;
	private Sprite spriteDown;
	private Sprite spriteUp;

	// Use this for initialization
	void Start () {
		game = SharedInfo.getCurrGame ();

		spriteDown = Resources.Load<Sprite>("Sprites/Layout/down");
		spriteUp = Resources.Load<Sprite>("Sprites/Layout/up");

		lastOrientation = getDeviceOrientation ();

		if (isPanelUp()) 
			currSprite = spriteDown;
		else
			currSprite = spriteUp;

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
				currSprite = spriteUp;

			}
			else{
				newPos.y = pos.y + height;
				currSprite = spriteDown;

			}
			
			buttonClicked = false;
		} 
		
		// Adapt
		if (orientationChanged) {
			
			if (isPanelUp())
				newPos.y = height / 2;
			else
				newPos.y = - height / 2;
			
			orientationChanged = false;
		} 

		GameObject.Find ("ArtefactStoryPanel").GetComponent<RectTransform> ().transform.position = newPos;
		GameObject.Find ("DetailButton").GetComponentsInChildren<Image> ()[1].sprite = currSprite;
	}
	

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
	
}
