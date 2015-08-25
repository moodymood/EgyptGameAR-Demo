using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour {



	public GameObject popUpPanel;
	public string popUpMessage;

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
}
