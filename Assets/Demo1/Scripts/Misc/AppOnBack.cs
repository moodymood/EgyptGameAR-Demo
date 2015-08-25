using UnityEngine;
using System.Collections;

public class AppOnBack : MonoBehaviour {

	public string levelToLoad;

	void Start () {	
	}
	
	void Update (){
		if (Input.GetKey (KeyCode.Escape)) {
			Application.LoadLevel (levelToLoad);	
		}
	}
}
