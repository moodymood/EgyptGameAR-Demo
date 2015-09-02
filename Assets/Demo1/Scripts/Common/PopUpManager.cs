using UnityEngine;
using System.Collections;
using UnityEngine.UI;


// HOW TO
// Create a panel and assign the panel to popUpPanel
public class PopUpManager : MonoBehaviour {
	
	public GameObject popUpPanel;
	private string levelToLoad;

	// Use this for initialization
	void Start () {
		popUpPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void setShowPopUp(bool value){
		popUpPanel.SetActive(value);
	}

	public void setPopUpMessage(string popUpMessage){
		popUpPanel.GetComponentsInChildren<Text> ()[0].text = popUpMessage;
	}

	public void setLevelToLoad(string levelToLoad){
		this.levelToLoad = levelToLoad;
	}

	public void loadLevel(){
		if (levelToLoad == "Quit")
			Application.Quit ();
		else {
			SharedInfo.getCurrGame ().resetGame ();
			Application.LoadLevel (levelToLoad);
		}
	}
}
