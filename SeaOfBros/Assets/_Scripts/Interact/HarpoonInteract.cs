using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HarpoonInteract : MonoBehaviour
{
    private bool attachPlayer = false;
    private bool isAttached = false;
    private bool enableInput = false;
    [SerializeField]
    private bool movingLR = false;
    [SerializeField]
    private bool movingUD = false;
    private bool fired;

    [SerializeField]
    private float rotateSpeed;

    private float timer = 0f;

    [SerializeField]
    private Transform playerPos;

    [SerializeField]
    private Camera playerCam;

    [SerializeField]
    private CharacterController characterController;

    [SerializeField]
    private Transform attachPlayerPos;

    [SerializeField]
    private GameObject harpoonSupport;

    [SerializeField]
    private GameObject harpoon;

    [SerializeField]
    private Transform harpoonDestination;

    [SerializeField]
    private Transform harpoonReturnDestination;

    private PlayerInput playerActionMap;

    [SerializeField]
    private AudioSource harpoonAudioSource;

    [SerializeField]
    private AudioClip harpoonUD;

    [SerializeField]
    private AudioClip harpoonLR;

    [SerializeField]
    private AudioClip harpoonFire;

    private void Start()
    {
        //create and enable a new player action map
        playerActionMap = new PlayerInput();
        playerActionMap.Enable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enableInput = true;
            playerPos = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enableInput = false;
        }
    }

    private void Update()
    {
        if (attachPlayer)
        {
            playerPos.position = attachPlayerPos.position;
            isAttached = true;
        }
        else
        {
            isAttached = false;
        }
    }

    private void FixedUpdate()
    {
        Vector2 harpoonMove = playerActionMap.Player.MoveHarpoon.ReadValue<Vector2>();

        if (isAttached)
        {
            if (!movingUD)
            {
                harpoonAudioSource.clip = harpoonLR;

                if (harpoonMove.x < 0f)
                {
                    harpoonSupport.transform.Rotate(new Vector3(0f, harpoonMove.x, 0f) * rotateSpeed * Time.deltaTime);
                    movingLR = true;
                    harpoonAudioSource.Play();
                }
                else if (harpoonMove.x > 0f)
                {
                    harpoonSupport.transform.Rotate(new Vector3(0f, harpoonMove.x, 0f) * rotateSpeed * Time.deltaTime);
                    movingLR = true;
                    harpoonAudioSource.Play();
                }
                else
                {
                    movingLR = false;
                    harpoonAudioSource.Stop();
                }
            }

            if (!movingLR)
            {
                harpoonAudioSource.clip = harpoonUD;

                if (harpoonMove.y < 0f)
                {
                    harpoonSupport.transform.Rotate(new Vector3(harpoonMove.y, 0f, 0f) * rotateSpeed * Time.deltaTime);
                    movingUD = true;
                    harpoonAudioSource.Play();
                }
                else if (harpoonMove.y > 0f)
                {
                    harpoonSupport.transform.Rotate(new Vector3(harpoonMove.y, 0f, 0f) * rotateSpeed * Time.deltaTime);
                    movingUD = true;
                    harpoonAudioSource.Play();
                }
                else
                {
                    movingUD = false;
                    harpoonAudioSource.Stop();
                }
            }
        }

        if(fired)
        {
            timer += Time.deltaTime * 3f;
            harpoon.transform.position = Vector3.Lerp(transform.position, harpoonDestination.position, timer);
        }
        else
        {
            timer += Time.deltaTime * 3f;
            harpoon.transform.position = Vector3.Lerp(transform.position, harpoonReturnDestination.position, timer);
        }
    }

    /// <summary>
    /// allows the player to thrust forward when an input action is detected from the action map
    /// </summary>
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && enableInput)
        {
            if(attachPlayer)
            {
                attachPlayer = false;
                characterController.enabled = true;
                harpoonSupport.transform.eulerAngles = new Vector3(0f, -78f, 0f);
            }
            else
            {
                attachPlayer = true;
                characterController.enabled = false;
            }
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed && enableInput)
        {
            harpoonAudioSource.clip = harpoonFire;
            harpoonAudioSource.Play();
            StartCoroutine(Fire());
        }
    }

    private IEnumerator Fire()
    {
        timer = 0f;

        fired = true;

        yield return new WaitForSeconds(2f);

        timer = 0f;

        fired = false;
    }
}
