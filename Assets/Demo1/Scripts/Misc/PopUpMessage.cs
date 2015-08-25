using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class PopUpMessage : MonoBehaviour{


	public string popUpTitle = "Default title";
	public string popUpMessage = "Default popup message";
	public int popUpWidth = 400;
	public int popUpHeight = 300;


	// Time enabled settings
	public bool timeEnabled = false;
	public float timeToWait = 5.0f;
	private float currentTime = 0.0f, executedTime = 0.0f;
	
	public bool showText = false;


	
	void Update()
	{
		currentTime = Time.time;

		if(showText && executedTime== 0.0f)
			executedTime = Time.time;
		
		if(executedTime != 0.0f)
		{
			if(currentTime - executedTime > timeToWait)
			{
				executedTime = 0.0f;
				showText = false;
			}
		}
	}

	void OnGUI()
	{
		Rect windowRect = new Rect((Screen.width - popUpWidth)/2, (Screen.height - popUpHeight)/2, popUpWidth, popUpHeight );
		if (showText) {
		//	windowRect = GUI.Window (0, windowRect, createWindow, texture);
		}
	}


	void createWindow(int windowID)
	{
		GUIStyle customLabelStyle = new GUIStyle();
		customLabelStyle.fontSize = 45;
		customLabelStyle.normal.textColor = new Color32(249, 223, 187, 100);

		GUIStyle customButtonStyle = new GUIStyle();
		customButtonStyle.fontSize = 50;
		customLabelStyle.onActive.textColor =  new Color32(255, 255, 255, 100);
		customButtonStyle.normal.textColor = new Color32(249, 223, 187, 100);



		int labelWidth = 300, labelHeight = 200;
		GUI.Label (new Rect ((popUpWidth - labelWidth)/2, (popUpHeight - labelHeight)/2, labelWidth, labelHeight), popUpMessage, customLabelStyle);

		// Use button only if not time enabled
		if (!timeEnabled) {
			int buttonWidth = 50, buttonHeight = 30;
			if (GUI.Button (new Rect ((popUpWidth - buttonWidth) / 2, (popUpHeight - buttonHeight - 60), buttonWidth, buttonHeight), "OK", customButtonStyle))
				showText = false;
		}
	}

}
