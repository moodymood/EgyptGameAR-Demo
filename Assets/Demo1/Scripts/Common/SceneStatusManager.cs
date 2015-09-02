using UnityEngine;
using System.Collections;

public class SceneStatusManager : MonoBehaviour {

	public GameObject infoPanel;
	public string currLevel;

	private SceneStatus sceneStatus;
	
	// Use this for initialization
	void Start () {
		sceneStatus = SharedInfo.getSceneStatus (); 
		if (sceneStatus.isVisited (currLevel))
			infoPanel.SetActive (false);
		else {
			infoPanel.SetActive (true);
			SharedInfo.getSceneStatus ().setVisited (currLevel);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void UpdateOnce(){
		sceneStatus = SharedInfo.getSceneStatus (); 
		if (sceneStatus.isVisited (currLevel))
			infoPanel.SetActive (false);
		else {
			infoPanel.SetActive (true);
			SharedInfo.getSceneStatus ().setVisited (currLevel);
		}
	}
	
	public void setShowPopUp(bool value){
		infoPanel.SetActive(value);
	}

	public void setVisited(){
		SharedInfo.getSceneStatus ().setVisited (currLevel);
	}


	
	//public void setPopUpMessage(string popUpMessage){
	//	infoPanel.GetComponentsInChildren<Text> ()[0].text = popUpMessage;
	//}



}
