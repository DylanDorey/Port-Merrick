using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Brad Farris]
 * Updated: 10.30.24
 * Purpose: Interaction
 */



    // GameObject should be what is doing the interaction

    public interface IInteractable
    {
        public string InteractionPrompt {  get; }    
        public bool Interact(PlayerInteractor interactor);
    }
