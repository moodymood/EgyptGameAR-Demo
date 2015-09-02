using UnityEngine;
using System.Collections;

public class ScreenOrientationAuto : MonoBehaviour {

	void Start () {	
		Screen.orientation = ScreenOrientation.AutoRotation;
	}
}
