using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateIntroEnd : MonoBehaviour {

	private Game game;
	private string introText = "Congratulations explorer!\nI hear that you have discovered a new tomb in the Valley of the Kings. This is wonderful news.\nAs your benefactor I would like you to retrieve some artefacts for me, as gifts I can then give to my family.\nI want these to be the pick of the bunch and suited perfectly to each member of my family, so there will be a list of conditions for each gift";
	private string endText = "Excellent! You have found beautiful artefacts that will make perfect gifts for my family. Keep up the good work; I will be more than happy to finance your next dig to find me even more wonderful things!";
	private string introButton = "Start";
	private string endButton = "Back To Menu";
	private string introTitle = "Introduction";
	private string endTitle = "The End";

	// Use this for initialization
	void Start () {
		string currText;
		string currButton;
		string currTitle;

		game = SharedInfo.getCurrGame ();	
		if (game.getCollectionStatus ().getTotalCollected () != game.getCollection ().getTotal ()){
			currText = introText;
			currButton = introButton;
			currTitle = introTitle;
		}else {
			currText = endText;
			currButton = endButton;
			currTitle = endTitle;
		}
		
		GameObject.Find ("IntroEndPanel").GetComponentsInChildren<Text>()[0].text = currTitle;
		GameObject.Find ("IntroEndPanel").GetComponentsInChildren<Text>()[1].text = currText;

		GameObject.Find ("IntroEndPanel").GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = currButton;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
