using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour
{
    private GameObject otherGO;

    [SerializeField]
    private GameObject chestPickup;

    [SerializeField]
    private GameObject dropZone;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Interactable"))
        {
            otherGO = other.gameObject;
            otherGO.transform.parent = transform;

            StartCoroutine(MoveChest());
        }
    }

    private IEnumerator MoveChest()
    {
        yield return new WaitForSeconds(3f);

        chestPickup.SetActive(true);
        dropZone.SetActive(true);

        otherGO.SetActive(false);
    }
}
