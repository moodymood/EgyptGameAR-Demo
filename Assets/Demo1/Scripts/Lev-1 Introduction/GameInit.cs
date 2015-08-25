using UnityEngine;
using System.Collections;

public class GameInit : MonoBehaviour {

	public TextAsset CollectionInfoXML;
	public Game currentGame;
	
	// Use this for initialization
	void Start () {
		currentGame = new Game (CollectionInfoXML.text);
		//currentGame.getCollectionStatus ().setAsCollected (currentGame.getCollection ().getArtefactById (0));
		//currentGame.setCurrentArtefact (currentGame.getCollection ().getArtefactById (0));
		//currentGame.setArtefactJustCollected (true);
	}


	void Awake() {	
		DontDestroyOnLoad(this);	
	} 


}



