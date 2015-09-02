using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public string levelToLoad;

	// Use this for initialization
	void Start () {
		Application.LoadLevel (levelToLoad);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
