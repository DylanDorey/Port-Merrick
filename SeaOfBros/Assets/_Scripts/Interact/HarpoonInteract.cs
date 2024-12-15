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
    private AudioSource harpoonFireAudioSource;

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
            UIManagement.Instance.EnableUseHarpoonUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enableInput = false;
            UIManagement.Instance.DisableUseHarpoonUI();
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

        if (isAttached && enableInput)
        {
            if (!movingUD)
            {
                if (harpoonMove.x < 0f)
                {
                    harpoonSupport.transform.Rotate(new Vector3(0f, harpoonMove.x, 0f) * rotateSpeed * Time.deltaTime);
                    movingLR = true;
                }
                else if (harpoonMove.x > 0f)
                {
                    harpoonSupport.transform.Rotate(new Vector3(0f, harpoonMove.x, 0f) * rotateSpeed * Time.deltaTime);
                    movingLR = true;
                }
                else
                {
                    movingLR = false;
                }
            }

            if (!movingLR)
            {
                if (harpoonMove.y < 0f)
                {
                    harpoonSupport.transform.Rotate(new Vector3(harpoonMove.y, 0f, 0f) * rotateSpeed * Time.deltaTime);
                    movingUD = true;
                }
                else if (harpoonMove.y > 0f)
                {
                    harpoonSupport.transform.Rotate(new Vector3(harpoonMove.y, 0f, 0f) * rotateSpeed * Time.deltaTime);
                    movingUD = true;
                }
                else
                {
                    movingUD = false;
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
                playerPos.transform.GetChild(0).transform.GetChild(1).transform.gameObject.SetActive(true);
                UIManagement.Instance.DisableHarpoonUI();
                UIManagement.Instance.EnableBaseUI();
            }
            else
            {
                attachPlayer = true;
                characterController.enabled = false;
                playerPos.transform.GetChild(0).transform.GetChild(1).transform.gameObject.SetActive(false);
                UIManagement.Instance.EnableHarpoonUI();
                UIManagement.Instance.DisableBaseUI();
                UIManagement.Instance.DisableUseHarpoonUI();
            }
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed && enableInput && attachPlayer)
        {
            StartCoroutine(Fire());
        }
    }

    private IEnumerator Fire()
    {
        harpoonFireAudioSource.Play();

        enableInput = false;

        timer = 0f;

        fired = true;

        yield return new WaitForSeconds(2f);

        enableInput = true;

        timer = 0f;

        fired = false;
    }
}
