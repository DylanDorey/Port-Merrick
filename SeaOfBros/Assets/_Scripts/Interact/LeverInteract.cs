using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteract : MonoBehaviour
{
    [SerializeField] private GameObject crosshair;
    [SerializeField] private Animator _platformAnimator;
    private bool interactable;
    private Animator _animator;
    



    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            crosshair.SetActive(true);
            interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            crosshair.SetActive(false);
            Debug.Log("OnTriggerExit Proccd");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("LeverOff", true);
        _platformAnimator.SetBool("PlatformRaised", false);
    }

    // Update is called once per frame
    void Update()
    {
        //Interacting with lever will activate a full cycle of the animation

        if (_animator != null && interactable == true)
        {            
            if (Input.GetButtonDown("Interact"))
            {
                _animator.SetTrigger("LeverTr");
                if (_platformAnimator.GetBool("PlatformRaised") == false)
                {
                    _platformAnimator.SetTrigger("RaisePlatform");
                }
                Debug.Log("LeverOn triggered");
            }
        }
    }
}
