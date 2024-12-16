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
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody chestRigidBody;
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private AudioSource audioSource;
    private bool interactable;
    private bool objPickedUp;
    private bool pickupFlag = false;

    private void Update()
    {
        if (objPickedUp)
        {
            transform.position = playerTransform.transform.position;
            transform.eulerAngles = new Vector3(0, playerTransform.eulerAngles.y, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactable = true;

            if (!pickupFlag)
            {
                pickupFlag = true;
                UIManagement.Instance.EnablePickupUI();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactable = false;
            UIManagement.Instance.DisablePickupUI();
            pickupFlag = false;
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && interactable && objPickedUp == false)
        {
            StartCoroutine(DelayPickupFlag());
            chestRigidBody.useGravity = false;
            boxCollider.enabled = false;
            audioSource.Play();
        }

        if(context.performed && interactable && objPickedUp)
        {
            objPickedUp = false;
            chestRigidBody.useGravity = true;
            boxCollider.enabled = true;
        }
    }

    private IEnumerator DelayPickupFlag()
    {
        yield return new WaitForSeconds(0.5f);

        objPickedUp = true;
        UIManagement.Instance.DisablePickupUI();
    }
}