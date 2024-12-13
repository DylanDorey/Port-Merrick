using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sloop : MonoBehaviour
{
    [SerializeField]
    private GameObject chest;

    public bool startAnim = false;

    // Start is called before the first frame update
    void Update()
    {
        if (startAnim)
        {
            StartCoroutine(StartSloopCoroutine());
        }
    }

    private IEnumerator StartSloopCoroutine()
    {
        startAnim = false;
        yield return new WaitForSeconds(15f);

        Instantiate(chest, new Vector3(90f, -0.3f, 4f), Quaternion.identity);

        Destroy(gameObject);
    }
}
