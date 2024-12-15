using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityStandardAssets.Utility;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ChestInteract : MonoBehaviour//, IInteractable
{
   // [SerializeField] private GameObject crosshair;
    [SerializeField] private Transform objTransform, playerTransform;
    [SerializeField] private Rigidbody chestRigidBody;
    [SerializeField] private bool interactable, objPickedUp;
    public GameObject player;
    



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //crosshair.SetActive(true);
            interactable = true;
            Debug.Log("Interactble true");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (objPickedUp == true)
            {
                objTransform.parent = null;
                //transform.position.eulerAngles = new Vector3(x, y, z);
                chestRigidBody.useGravity = true;
                interactable = false;
                objPickedUp = false;
            }
            else if (objPickedUp == false)
            {
                //crosshair.SetActive(false);
                interactable = false;
            }
            Debug.Log("OnTriggerExit Proccd");
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && interactable)
        {
            //This was how it was working before
                //objTransform.parent = playerTransform;
            transform.eulerAngles = new Vector3(0, player.transform.eulerAngles.y, 0);
            //crosshair.SetActive(false);
            chestRigidBody.useGravity = false;
            objPickedUp = true;
            Debug.Log("Interact triggered");
        }
    }


    private void Start()
    {
        chestRigidBody = GetComponent<Rigidbody>();
        objTransform = GetComponent<Transform>();
        //player = 
        //crosshair = GetComponent<GameObject>();

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
        if (objPickedUp)
        {
            objTransform.position = playerTransform.transform.position;
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