using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeverInteract : MonoBehaviour
{
    //[SerializeField] private GameObject crosshair;
    [SerializeField] private Animator _platformAnimator;
    [SerializeField] private Animator _leverAnimator;

    [SerializeField]
    private bool switchOn;

    [SerializeField]
    private bool enableInput = false;

    [SerializeField]
    private AudioSource leverAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //crosshair.SetActive(true);
            enableInput = true;
            UIManagement.Instance.EnableLeverUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //crosshair.SetActive(false);
            enableInput = false;
            UIManagement.Instance.DisableLeverUI();
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && enableInput)
        {
            StartCoroutine(DelayElevator());
        }
    }

    private IEnumerator DelayElevator()
    {
        if (_platformAnimator.GetBool("Raising") == true)
        {
            _leverAnimator.SetBool("On", !_leverAnimator.GetBool("On"));
            leverAudioSource.Play();

            yield return new WaitForSeconds(3f);

            _platformAnimator.SetBool("Raising", false);
            _platformAnimator.gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            _leverAnimator.SetBool("On", !_leverAnimator.GetBool("On"));
            leverAudioSource.Play();

            yield return new WaitForSeconds(3f);

            _platformAnimator.SetBool("Raising", true);
            _platformAnimator.gameObject.GetComponent<AudioSource>().Play();
        }

        leverAudioSource.Play();

        switchOn = !switchOn;
    }
}
