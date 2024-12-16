using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DropZoneInteract : MonoBehaviour
{
    [SerializeField]
    private GameObject chestSpawnPrefab;

    [SerializeField]
    private GameObject chestCarryPrefab;

    private bool enableInput = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            enableInput = true;
            UIManagement.Instance.EnableTurnInUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enableInput = false;
            UIManagement.Instance.DisableTurnInUI();
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && enableInput)
        {
            Destroy(chestCarryPrefab, 0.2f);
            chestSpawnPrefab.SetActive(true);
        }
    }
}
