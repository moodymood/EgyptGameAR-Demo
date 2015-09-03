/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using UnityEngine;
using UnityEngine.UI;

namespace Vuforia
{
	/// <summary>
	/// A custom handler that implements the ITrackableEventHandler interface.
	/// </summary>
	public class CustomTrackableEventHandler : MonoBehaviour,
	ITrackableEventHandler
	{
		#region PRIVATE_MEMBER_VARIABLES
		
		private TrackableBehaviour mTrackableBehaviour;
		private Game game;

		#endregion // PRIVATE_MEMBER_VARIABLES
		
		
		
		#region UNTIY_MONOBEHAVIOUR_METHODS
		
		void Start()
		{

			game = SharedInfo.getCurrGame ();
		

			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}
		}
		
		#endregion // UNTIY_MONOBEHAVIOUR_METHODS
		
		
		
		#region PUBLIC_METHODS
		
		/// <summary>
		/// Implementation of the ITrackableEventHandler function called when the
		/// tracking state changes.
		/// </summary>
		public void OnTrackableStateChanged(
			TrackableBehaviour.Status previousStatus,
			TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
			    newStatus == TrackableBehaviour.Status.TRACKED ||
			    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				OnTrackingFound();
			}
			else
			{
				OnTrackingLost();
			}
		}
		
		#endregion // PUBLIC_METHODS
		
		
		
		#region PRIVATE_METHODS
		
		
		private void OnTrackingFound()
		{

			bool isVisible = false;
			Collider artefactCollider = new Collider();
			Renderer artefactRenderer = new Renderer(), artefactRendererExtra = new Renderer(), questionMarkRenderer = new Renderer();
			Artefact currArtefact = new Artefact ();

			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

			// Each time a new artefact is found, clean any old pup up messages
			GameObject.Find("CameraFinderSceneManager").GetComponent<PopUpManager>().setShowPopUp(false);
			
			// Enable rendering:
			foreach (Renderer component in rendererComponents)
			{
				string componentName = component.gameObject.name.Replace("Texture","");

				if(componentName == "Cippus0" || componentName == "Cippus1"){
					if(componentName == "Cippus0"){
						artefactRendererExtra = component;
					}
					componentName = "Cippus";
				}

				currArtefact = game.getCollection().getArtefactByName(componentName);
				//Debug.Log("Renderer: " + componentName);

				if(componentName == "FindOtherFirst")			
					questionMarkRenderer = component;

				else if(currArtefact != null)
					artefactRenderer = component;	
			}
			
			// Enable colliders:
			foreach (Collider component in colliderComponents)
			{
				currArtefact = game.getCollection().getArtefactByName(component.name);
				//Debug.Log("Collider: " + component.name);

				if(currArtefact != null){
					artefactCollider = component;
				}
			}


			// Show the artefact
			if (currArtefact != null && currArtefact.getId() <= game.getCollectionStatus().getNextToCollect()) {
				// Only if the previous message has already been dismissed
				if(GameObject.Find ("InfoPanel-CameraFinder") == null){
					// Only if first artefact and not already collrcted
					// If you dont want to show anymore after the OK button was pressed add:
					// && !SharedInfo.getSceneStatus().isVisited("ARartefact");
					if(currArtefact.getId() == 0 && !game.collectionStatus.isCollected(currArtefact)  && !SharedInfo.getSceneStatus().isVisited("ARartefact")){
						// Retrive unactive panel
						Component[] infoPanels = GameObject.Find("InfoPanels").GetComponentsInChildren( typeof(Transform), true );
						foreach(Component temp in infoPanels){
							if (temp.name == "InfoPanel-ARartefact"){
								temp.gameObject.SetActive(true);
							}
						}
						GameObject.Find("InfoPanel-ARartefact").GetComponent<SceneStatusManager>().setShowPopUp(true);
						// OR
						//SharedInfo.getSceneStatus().setVisited ("ARartefact");
						//GameObject.Find("InfoPanel-ARartefact").GetComponent<SceneStatusManager>().UpdateOnce();
					}

				}
				questionMarkRenderer.enabled = false;
				artefactCollider.enabled = true;
				artefactRenderer.enabled = true;
				if(currArtefact.getName() == "Cippus")
					artefactRendererExtra.enabled = true;

			} else {

				artefactCollider.enabled = false;
				artefactCollider.enabled = false;
				questionMarkRenderer.enabled = true;

			}
			
			//Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
		}

		
		
		private void OnTrackingLost()
		{
			// pop up stop appearing only if OK was pressed, not when it desappear for tracking lost
			if (GameObject.Find ("InfoPanel-ARartefact") != null) {
				GameObject.Find("InfoPanel-ARartefact").GetComponent<SceneStatusManager>().setShowPopUp(false);
				// After it has been seen, set to unseen again as untill the OK button is pressed, the pop-up
				// should keep appering
				SharedInfo.getSceneStatus().setUnvisited ("ARartefact");
				//GameObject.Find("InfoPanel-ARartefact").GetComponent<SceneStatusManager>().UpdateOnce();
			}


			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			
			// Disable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = false;
			}
			
			// Disable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = false;
			}
			
			//Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
		}
		
		#endregion // PRIVATE_METHODS
	}
}