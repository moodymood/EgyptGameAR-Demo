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
		if (won) {
			GameObject.Find ("GameTitle").GetComponentInChildren<Text> ().text = "You Won!";
			Transform containerTransform = GameObject.Find("Container").gameObject.transform;
			effect = (Transform)Instantiate (particlesEffect, containerTransform.position, containerTransform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Destroy (effect.gameObject, 0);
		}
	
	}
}
