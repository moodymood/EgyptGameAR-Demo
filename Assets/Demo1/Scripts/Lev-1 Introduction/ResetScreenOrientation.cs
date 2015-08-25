using UnityEngine;
using System.Collections;

public class ResetScreenOrientation : MonoBehaviour {

	void Start () {	
	}
	
	void Update (){
		if (Input.GetKey (KeyCode.Escape)) 
			Screen.orientation = ScreenOrientation.AutoRotation;
	}

	public void reset(){
		Screen.orientation = ScreenOrientation.AutoRotation;
	}
}
