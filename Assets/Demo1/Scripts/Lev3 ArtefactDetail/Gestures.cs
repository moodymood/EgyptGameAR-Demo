using UnityEngine;
using System.Collections;

public class Gestures : MonoBehaviour {

	// TODO
	// not calling gestures
	// get the fucking right screen orientation event
	
	public Game game;
	public string message;
	public float perspectiveZoomSpeed = 0.5f; 

	void Start () {
		game = SharedInfo.getCurrGame ();
	}
	
	void Update()

	{

		// Only is the panel is hidden
		if (!isPanelUp()) {

				Artefact currentArtefact = game.getCurrentArtefact ();
				Debug.Log ("artefact" + currentArtefact.getName());
				if (currentArtefact != null) {
					Transform artTransform = GameObject.Find (currentArtefact.getName ()).transform;
					if (Input.touchCount == 1) {
						var touch = Input.GetTouch (0);
		
							switch (touch.phase) {
							
								case TouchPhase.Moved:

								artTransform.Translate (0, touch.deltaPosition.y * 0.3f, 0);
								artTransform.Rotate (0, -touch.deltaPosition.x * 0.3f, 0);												
								
								if (!isVector3DInsideBottomWindow (artTransform.position)) {
									artTransform.Translate (0, -touch.deltaPosition.y * 0.3f, 0);
									artTransform.Rotate (0, +touch.deltaPosition.x * 0.3f, 0);	
								}
								break;	
							}
					} else if (Input.touchCount == 2) {

						Touch touchZero = Input.GetTouch (0);
						Touch touchOne = Input.GetTouch (1);

						Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
						Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
					
						float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
						float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
					
						float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

						GetComponent<Camera> ().fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;			
						GetComponent<Camera> ().fieldOfView = Mathf.Clamp (GetComponent<Camera> ().fieldOfView, 20.1f, 120.9f);
						}
				} else {
					Debug.Log ("TODO selectedArtefact is null");
				}
			}
 
	}


	public bool isVector3DInsideBottomWindow(Vector3 artefactPos){
		Vector3 pos = Camera.main.WorldToViewportPoint (artefactPos);
		pos.x = Mathf.Clamp01(pos.x);
		pos.y = Mathf.Clamp01(pos.y);
		if (pos.x > 0 && pos.x < 1 && pos.y > 0 && pos.y < 1)
			return true;
		else
			return false;
	}


	/*
	public bool isVector2DInsideTopWindow(Vector2 fingerPos){
		Vector2 pos = Camera.main.ScreenToViewportPoint(fingerPos);
		Debug.Log ("pos" + pos);
		pos.x = Mathf.Clamp01(pos.x);
		pos.y = Mathf.Clamp01(pos.y);
		Debug.Log ("posx" + pos.x);
		Debug.Log ("posy" + pos.y);
		if (pos.x > 0.0 && pos.x < 1.0 && pos.y > 0.35 && pos.y < 1)
			return true;
		else
			return false;
	}
	*/


	public bool isPanelUp(){
		if (GameObject.Find ("ArtefactStoryPanel").GetComponent<RectTransform> ().transform.position.y > 0)
			return true;
		else
			return false;
	}

	

	void OnGUI(){
//		GUIStyle guiStyle = new GUIStyle();
//		guiStyle.fontSize = 50; //change the font size
//		GUI.Label (new Rect (20, 20, 400, 400), "panelUp" + GameObject.Find ("ArtefactDetailManager").GetComponent<PanelStatus> ().panelUp, guiStyle);
	}
	
}
