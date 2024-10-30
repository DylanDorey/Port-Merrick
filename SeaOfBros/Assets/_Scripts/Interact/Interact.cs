using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Brad Farris
 * Updated: 10.30.24
 */



    // GameObject should be what is doing the interaction

    public interface IInteractable
    {
        void Interact(GameObject interactor);
    }
