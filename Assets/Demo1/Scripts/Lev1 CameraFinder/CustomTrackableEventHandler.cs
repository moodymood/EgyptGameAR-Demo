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
			GameObject.Find("Collection").GetComponent<PopUpManager>().setShowPopUp(false);
			
			// Enable rendering:
			foreach (Renderer component in rendererComponents)
			{
				string componentName = component.gameObject.name.Replace("Texture","");

				if(componentName == "Horus0" || componentName == "Horus1"){
					if(componentName == "Horus0"){
						artefactRendererExtra = component;
					}
					componentName = "Horus";
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
				questionMarkRenderer.enabled = false;
				artefactCollider.enabled = true;
				artefactRenderer.enabled = true;
				if(currArtefact.getName() == "Horus")
					artefactRendererExtra.enabled = true;

			} else {

				artefactCollider.enabled = false;
				artefactCollider.enabled = false;
				questionMarkRenderer.enabled = true;

			}
			
			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
		}
		
		
		private void OnTrackingLost()
		{
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
			
			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
		}
		
		#endregion // PRIVATE_METHODS
	}
}