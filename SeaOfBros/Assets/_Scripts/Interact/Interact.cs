using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{

    private PlayerInput inputActions;

    private void Awake()
    {
        inputActions = new PlayerInput();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }





    private void OnEnable()
    {
        inputActions.Enable();

    }


    private void OnDisable()
    {

        inputActions.Disable();
    }



    private void OnInteract(InputAction.CallbackContext context)
    {

    }






}
