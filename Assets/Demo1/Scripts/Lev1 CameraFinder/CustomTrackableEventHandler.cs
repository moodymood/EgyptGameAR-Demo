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
			Collider artefactCollider = new Collider(), questionMarkCollider = new Collider();
			Artefact currArtefact;

			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			
			// Enable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = true;
			}
			
			// Enable colliders:
			foreach (Collider component in colliderComponents)
			{
				//Need to reset the message when a new artefac is found
				GameObject.Find("Collection").GetComponent<PopUpManager>().setShowPopUp(false);
				currArtefact = game.getCollection().getArtefactByName(component.gameObject.name);
				Debug.Log("component"+(component.name));


				if(component.name == "FindOtherFirst"){
					
					questionMarkCollider = component;
					//Debug.Log("questionMarkCollider"+questionMarkCollider.name);
				
					
				}
				// It is an artefact
				else if(currArtefact != null){
					artefactCollider = component;
					//Debug.Log("artefactCollider"+artefactCollider.name);
					if(currArtefact.getId() <= game.getCollectionStatus().getNextToCollect())
						isVisible = true;
					else
						isVisible = false;
				}
			}

			if (!isVisible) {

				artefactCollider.gameObject.SetActive (false);
				questionMarkCollider.enabled = false;

				//GameObject.Find("Collection").GetComponent<PopUpManager>().setShowPopUp(true);
				//GameObject.Find("Collection").GetComponent<PopUpManager>().setPopUpMessage( 
				//    "There is something hiding here, but you need to follow the collection order to find out what!");

			} else {
				questionMarkCollider.gameObject.SetActive (false);
				artefactCollider.enabled = true;
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