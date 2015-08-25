using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnSwipe : MonoBehaviour {

	private int offSet = 200;
	private int currPanel = 1;
	private int numPanel = 5;
	Vector2 startPos;

	// Use this for initialization
	void Start () {
		startPos = new Vector2 (0, 0);
		Screen.orientation = ScreenOrientation.Portrait;
	}
	
	// Update is called once per frame
	void Update () {



		if (Input.touchCount == 1) {
			var touch = Input.GetTouch (0);


			switch (touch.phase) {
				
				case TouchPhase.Began:
						
					startPos = touch.position;
					break;	

				case TouchPhase.Ended:
					
					Vector2 endPos = touch.position;
				
					if(startPos.x - endPos.x > offSet){ // swipte left
						if(currPanel < numPanel){
							GameObject.Find("Panel"+currPanel).transform.Translate(new Vector2(-Screen.width, 0));
							currPanel++;
						}
					}else if(startPos.x - endPos.x < (- offSet)){ // swipe right
						if(currPanel > 1){
							currPanel--;
							GameObject.Find("Panel"+currPanel).transform.Translate(new Vector2(Screen.width, 0));
						}
					}
					GameObject.Find ("Step").GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/Instructions/instr-clear"+currPanel);

					break;	
			}



		}
	}

	void OnGUI(){
				GUIStyle guiStyle = new GUIStyle();
				guiStyle.fontSize = 50; //change the font size
//				GUI.Label (new Rect (20, 60, 400, 400), "currPanel" + currPanel, guiStyle);
//				GUI.Label (new Rect (20, 120, 400, 400), "swipeLeft" + swipeLeft, guiStyle);
//				GUI.Label (new Rect (20, 180, 400, 400), "swipeRight" + swipeRight, guiStyle);
//				GUI.Label (new Rect (20, 240, 400, 400), "start" + startPos + "end" + endPos, guiStyle);
			
	}
}
