using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Brad Farris]
 * Updated: 11.18.24
 * Purpose: Interaction
 */


public class Interact : MonoBehaviour
{
    public GameObject crosshair;
    public Transform objTransform, playerTransform;
    public bool interactable;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            crosshair.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            crosshair.SetActive(false);

        }
    }


}









/* GameObject should be what is doing the interaction

    public interface IInteractable
    {
        public string InteractionPrompt {  get; }    
        public bool Interact(PlayerInteractor interactor);
    }


*/
