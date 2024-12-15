using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject crosshair;
    
    
    // Start is called before the first frame update
    void Start()
    {
        crosshair.SetActive(false);
    }
}
