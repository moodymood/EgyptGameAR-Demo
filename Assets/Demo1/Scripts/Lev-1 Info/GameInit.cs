using UnityEngine;
using System.Collections;

public class GameInit : MonoBehaviour {

	public TextAsset CollectionInfoXML;
	public Game currentGame;
	public SceneStatus currentSceneStatus;
	
	// Use this for initialization
	void Start () {
		currentGame = new Game (CollectionInfoXML.text);
		currentSceneStatus = new SceneStatus ("CameraFinder","AfterCollection","ARartefact","ArtefactStory");
		//currentSceneStatus = new SceneStatus ("CameraFinder","AfterCollection","ARartefact","ArtefactStory","ArtefactModel");
	
		currentSceneStatus.setVisited ("AfterCollection");
		//currentSceneStatus.setVisited ("ArtefactModel");
		//currentGame.getCollectionStatus ().setAsCollected (currentGame.getCollection ().getArtefactById (0));
		//currentGame.setCurrentArtefact (currentGame.getCollection ().getArtefactById (0));
		//currentGame.setArtefactJustCollected (true);
	}


	void Awake() {	
		DontDestroyOnLoad(this);	
	} 


}



