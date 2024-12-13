using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonController : MonoBehaviour
{
    private bool attachPlayer = false;
    private bool isAttached = false;

    private Transform playerPos;

    [SerializeField]
    private Transform attachPlayerPos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerPos = other.transform;
            attachPlayer = true;
        }
    }

    private void Update()
    {
        if(attachPlayer)
        {
            playerPos.position = attachPlayerPos.position;
            isAttached = true;
        }

        if(isAttached)
        {

        }
    }
}
