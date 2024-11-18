using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityStandardAssets.Utility;
using UnityEngine.InputSystem;

public class ChestInteract : MonoBehaviour//, IInteractable
{
    [SerializeField] private GameObject crosshair;
    [SerializeField] private Transform objTransform, playerTransform;
    [SerializeField] private Rigidbody chestRigidBody;
    private bool interactable, objPickedUp;
    



    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            crosshair.SetActive(true);
            interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (objPickedUp == true)
            {
                objTransform.parent = null;
                chestRigidBody.useGravity = true;
                interactable = false;
                objPickedUp = false;
            }
            else if (objPickedUp == false)
            {
                crosshair.SetActive(false);
                interactable = false;
            }
            Debug.Log("OnTriggerExit Proccd");
        }
    }



    private void Start()
    {
        chestRigidBody = GetComponent<Rigidbody>();
        objTransform = GetComponent<Transform>();

        if (chestRigidBody != null )
        {
            Debug.Log("chestRigidBody loaded");
        }
        if (objTransform != null )
        {
            Debug.Log("objTransform = " + objTransform);
        }
    }


    private void Update()
    {
        if (interactable == true)
        {
            if (Input.GetButtonDown("Interact"))
            {
                objTransform.parent = playerTransform;
                crosshair.SetActive(false);
                chestRigidBody.useGravity = false;
                objPickedUp = true;
                Debug.Log("Interact triggered");
            }
            if (objPickedUp == true && Input.GetButtonDown("Drop"))
            {
                objTransform.parent = null;
                chestRigidBody.useGravity = true;
                objPickedUp = false;
                Debug.Log("Drop triggered");
            }
        }





    }










}




/*
[SerializeField] private string _prompt;

public string InteractionPrompt => _prompt;

public bool Interact(PlayerInteractor interactor)
{
    Debug.Log("Chest Picked Up!");
    return true;

}
*/