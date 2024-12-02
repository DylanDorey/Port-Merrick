using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionRadius = 0.3f;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _interactableCollider = new Collider[1];
    [SerializeField] private int _numFound;

   

    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionRadius, _interactableCollider, _interactableMask);

        if (_numFound > 0)
        {
            /*
                var interactable = _interactableCollider[0].GetComponent<IInteractable>();

            if (interactable != null && Keyboard.current.eKey.wasPressedThisFrame)
            {
                interactable.Interact(this);
            }
            */
        }
    }


}
