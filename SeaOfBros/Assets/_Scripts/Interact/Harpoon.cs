using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour
{
    private bool attach;

    private GameObject otherGO;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Interactable"))
        {
            otherGO = other.gameObject;
            attach = true;
        }
    }

    private void Update()
    {
        if(attach)
        {
            otherGO.transform.position = transform.position;
        }
    }
}
