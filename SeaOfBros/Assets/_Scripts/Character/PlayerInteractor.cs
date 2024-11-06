using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionRadius = 0.3f;
    [SerializeField] private LayerMask _interactableMask;


    private void Update()
    {
        Physics.OverlapSphere(_interactionPoint.position, _interactionRadius, _interactableMask);
    }


}
