using UnityEngine;
using System.Collections;

public class OnSingleTouch : MonoBehaviour {
	
	// When the which the script is assigned to is touched
	// the app goes to level Level
	// On the touch of the object a feedback is implmemented too
	
	// SharedInfo components
	private Game game;
	public string levelToGo = "Collection";
	public Transform particlesEffect;
	private bool waiting = false;
	private float coroutineTime = 0.7f;

	//public string message;

	bool touchInsideObject;

	void Start () {
		game = SharedInfo.getCurrGame ();
		touchInsideObject = false;
	}
	
	
	// Update is called once per frame
	void Update () {
		onTouchEvent ();
		onClickEvent ();
	}
	
	
	
	void onTouchEvent()
	{

		if (Input.touchCount == 1)
		{
			Transform hitObject = getHitObject("singleTouch");
			
			if(hitObject!= null && hitObject.name == transform.name ){


				//message = "inside touch";
				//message += "\nhitObject.name " + hitObject.name;
				//message += "\ntransform.name " + transform.name;

				switch(Input.GetTouch(0).phase){

					case TouchPhase.Began:
						//message += "\ntouch began";
						touchInsideObject = true;
						break;
						
					case TouchPhase.Ended:
						//message += "\ntouch end";
						//message += "\ntouchInsideObject is " + touchInsideObject.ToString();
						if(touchInsideObject){
							StartCoroutine(callParticlesEffect());
							StartCoroutine(resize());
							StartCoroutine(loadLevel());
							
						}
						break;
				}
			}
		}//else
			//message = "NOT touching";
	}



	// Bag feedback on click
	public IEnumerator callParticlesEffect(){
		waiting = true;

		Transform effect = (Transform) Instantiate (particlesEffect, transform.position, transform.rotation);
		Destroy (effect.gameObject, coroutineTime);
		yield return new WaitForSeconds(coroutineTime);

		waiting = false;
	}


	public IEnumerator resize(){
		if (waiting) {
			transform.localScale += new Vector3 (-0.5F, -0.5F, -0.5F);
			yield return new WaitForSeconds (coroutineTime * 1/5);	
			transform.localScale -= new Vector3 (-0.5F, -0.5F, -0.5F);	
		}
	}

	public IEnumerator loadLevel() {	

		while(waiting)       
			yield return new WaitForSeconds(0.1f);
		Application.LoadLevel(levelToGo);

		//CameraFade.StartAlphaFade( Color.black, false, 1.5f, 0.0f, () => { Application.LoadLevel(levelToGo); } );
	}
	
	
	void onClickEvent()
	{
		if (Input.GetMouseButtonDown (0)) {
			Transform hitObject = getHitObject("mouseClick");
			if(hitObject!= null && hitObject.name == transform.name)
			{
				StartCoroutine(callParticlesEffect());
				StartCoroutine(resize());
				StartCoroutine(loadLevel());
			}
		}
	}
	
	
	public Transform getHitObject(string input)
	{
		Transform hitObject = null;		
		Ray ray;
		// input == "singleTouch"
		if (input == "singleTouch")
			ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
		// input == "mouseClick"
		else 
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit))
			hitObject = hit.transform;
		return hitObject;
	}
	
	// Debug
	//void OnGUI()
	//{
	//	GUI.Label (new Rect (20, 80, 400, 400), message);
	//}
	
	//void OnTriggerEnter(Collider other)
	//{
	//bagCollided = true;
	//game.setCurrentArtefact(game.getCollection ().getArtefactByName (other.gameObject.name));		                  	
	//}
	
	
}
