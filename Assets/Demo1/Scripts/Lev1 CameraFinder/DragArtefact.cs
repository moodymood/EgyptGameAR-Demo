using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class DragArtefact : MonoBehaviour { 

	// Drag one of the artefact around, when one of the touch the object
	// objectToHit the application goes to levelToGo

	private Game game;
	
	public string levelToGo = "ArtefactDetail";
	public Transform effectTransform;
	private float coroutineTime = 2f;

	private Transform artefactTransform;
	private Transform bagTransform;
			
	private Vector3 startPoint;
	private bool draggingArtefact;
	private bool waiting;

	private bool isFirstTime;

	private string message;


			
		void Start()
		{
			game = SharedInfo.getCurrGame ();
			draggingArtefact = false;
			isFirstTime = false;
			waiting = false;
			startPoint = transform.position;
			
		}
		
		void Update()
		{
		


		if (Input.touchCount == 1) {
				
				Vector3 touchedPoint = Input.GetTouch (0).position;
				Ray ray = Camera.main.ScreenPointToRay (touchedPoint);
				RaycastHit hit;
				
				bool isArtefactHit;		

				// If I am hitting something
				if (Physics.Raycast (ray, out hit)) {
					if(hit.transform.name == "BagModel"){
						bagTransform = hit.transform;
						isArtefactHit = false;
					}else {
						artefactTransform = hit.transform;
						game.setCurrentArtefact(game.getCollection().getArtefactByName(artefactTransform.name));
						isArtefactHit = true;
					}
															
					switch (Input.GetTouch (0).phase) {
							
						case TouchPhase.Began:

							// The hit object exists in the collection
							if(isArtefactHit){
								draggingArtefact = true;
								startPoint = artefactTransform.position;
							}
							break;

						case TouchPhase.Moved:
							// I am dragging the artefactm, so I move it
							if(isArtefactHit && draggingArtefact){
									hit.transform.position = Camera.main.ScreenToWorldPoint (
										new Vector3 (touchedPoint.x, touchedPoint.y, startPoint.z));
							// I am touching the bag but carrying the artefact too
							}else if(draggingArtefact){
								// Remember, The bag is in the first position
								// If the current artefact hasn't been collected yet
								
								if (!game.getCollectionStatus ().isCollected (game.getCurrentArtefact())) {	
										
										game.getCollectionStatus().setAsCollected (game.getCurrentArtefact());
										game.setArtefactJustCollected(true);
										isFirstTime = true;
									
										StartCoroutine(callParticlesEffect(artefactTransform.gameObject));
										StartCoroutine(resize());		
										StartCoroutine(rotate());
										
										StartCoroutine(loadLevel());
								// The artefact has been colllected
								}else{
									// Artefact collected, so show error message
									if(!isFirstTime)
										GameObject.Find("CameraFinderSceneManager").GetComponent<PopUpManager>().setShowPopUp(true);
										GameObject.Find("CameraFinderSceneManager").GetComponent<PopUpManager>().setPopUpMessage( 
											"You already have " + game.getCurrentArtefact().getName() + " in your bag");
								}
							}
								
							break;
							
						case TouchPhase.Ended:
							// The hit object exists in the collection
							if(draggingArtefact){
								draggingArtefact = false;
								artefactTransform.position = startPoint;
							}
							break;
							
					}
			
				}// else {
					//CameraDevice.Instance.SetFocusMode (CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
				//}			
			} 
		}

	public IEnumerator callParticlesEffect(GameObject current){
		waiting = true;

		Transform effect =  (Transform) Instantiate(effectTransform, bagTransform.position, bagTransform.rotation);
		Destroy(effect.gameObject, 3);
		Destroy (current);
		yield return new WaitForSeconds(coroutineTime);

		waiting = false;
	}
	

	public IEnumerator resize(){
		if (waiting) {
			bagTransform.localScale += new Vector3 (-1.2f, -1.2f, -1.2f);
			yield return new WaitForSeconds (coroutineTime * 1/4);		
			bagTransform.localScale -= new Vector3 (-1.2f, -1.2f, -1.2f);
		}
	}

	public IEnumerator rotate(){		
		while(waiting){
			bagTransform.Rotate(0, 15, 0, Space.Self);
			yield return new WaitForSeconds(coroutineTime * 0.01f);
		}
		bagTransform.Rotate(0, 5, 0, Space.Self);	
	}
	

	public IEnumerator loadLevel() {	
		while(waiting)       
			yield return new WaitForSeconds(0.1f);

		Application.LoadLevel(levelToGo);		
		//CameraFade.StartAlphaFade( Color.black, false, 1.5f, 0.0f, () => { Application.LoadLevel(levelToGo); } );
	}

	void OnGUI () {
//		GUIStyle guiStyle = new GUIStyle();
//		guiStyle.fontSize = 50; //change the font size
//		GUI.Label(new Rect(20, 220,600,200), "is already collected" + message, guiStyle);
	}




}