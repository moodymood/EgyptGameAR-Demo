using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Collections;

public class UpdateMenu : MonoBehaviour {


	// TODO
	// if it is the first time show instructions, new came, quit
	// if it not the first time should be instructions, new game, continue, quit
	private Game game;
	private bool won;
	public Transform particlesEffect;
	private Transform effect;


	// Use this for initialization
	void Start () {
		game = SharedInfo.getCurrGame ();
		won = (game.getCollection ().getTotal () == game.getCollectionStatus ().getTotalCollected ());
		string statusMessage = game.getCollectionStatus().getTotalCollected() + " out of " + game.getCollection().getTotal() + "\n already collected.";
		string victoryMessage = "";
		if (won) {
			// Update status message
			victoryMessage = "You Won!";

			// Create particle effect
			Transform containerTransform = GameObject.Find("Container").gameObject.transform;
			effect = (Transform)Instantiate (particlesEffect, containerTransform.position, containerTransform.rotation);

		}
		GameObject.Find ("GameStatus").GetComponentInChildren<Text> ().text = statusMessage;
		GameObject.Find ("WonMessage").GetComponentInChildren<Text> ().text = victoryMessage;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Destroy (effect.gameObject, 0);
		}
	
	}
}
