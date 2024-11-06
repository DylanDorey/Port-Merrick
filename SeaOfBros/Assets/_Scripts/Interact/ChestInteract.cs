using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    
    public string InteractionPrompt => _prompt;

    public bool Interact(PlayerInteractor interactor)
    {
        Debug.Log("Chest Picked Up!");
        return true;
    }
}
