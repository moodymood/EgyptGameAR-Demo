using UnityEngine;
using System.Collections;


public class ShowObject : MonoBehaviour {

	// Assign this script to the object you want to show
	// Define the position

	public int x = 100, y = 100, z = 50;

	void Start () {
	}
	
	void Update () {
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, z));
	}

	// Debug
	//void OnGUI()
	//{
	//GUI.Label(new Rect(bagX, Screen.height - bagY, 40, 20), message);		
	//}
}
