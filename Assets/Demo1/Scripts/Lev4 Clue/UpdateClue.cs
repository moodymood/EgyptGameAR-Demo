using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateClue : MonoBehaviour {

	private Game game;
	private Artefact nextArtefactToCollect;
	private int artefactId;

	// Use this for initialization
	void Start () {

		game = SharedInfo.getCurrGame ();

		artefactId = game.getCollectionStatus ().getNextToCollect ();
		nextArtefactToCollect = game.getCollection ().getArtefactById (artefactId);
			
		GameObject.Find ("CluePanel").GetComponentsInChildren<Text>()[0].text = getTitleFromNumber(nextArtefactToCollect.getId() + 1);
		GameObject.Find ("CluePanel").GetComponentsInChildren<Text>()[1].text = nextArtefactToCollect.getClue ();



	}
	
	// Update is called once per frame
	void Update () {

	}

	private string getTitleFromNumber(int id){
		string res = id + "";
		switch (id)
		{
		case 1:
			res += "st";
			break;
		case 2:
			res += "nd";
			break;
		case 3:
			res += "rd";
			break;
		case 4:
			res += "th";
			break;
		case 5:
			res += "th";
			break;
		}
		return res+= " CLUE";
	}
}
