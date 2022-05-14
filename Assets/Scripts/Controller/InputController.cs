using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Input inputActions;
    public static InputController Instance {get; protected set;}
    private void Awake() {
        //ensure singleton
        if(Instance != null){
            Destroy(this);
            return;
        }
        Instance = this;

        //create instance
        inputActions = new();

        inputActions.Player.Move.performed += ctx => dir = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += _ => dir = Vector2.zero;

        inputActions.Player.Interact.performed += _ => interactionFlag = true;
        inputActions.Player.ClearHand.performed += _ => clearHandFlag = true;

        inputActions.Player.CameraMovement.performed += ctx => mouseMovement = ctx.ReadValue<Vector2>();
        inputActions.Player.CameraMovement.canceled += ctx => mouseMovement = Vector2.zero;
    }

    private void OnEnable() {
        inputActions.Enable();
    }
    private void OnDisable() {
        inputActions.Disable();    
    }

    [Header("Input Info")]
    public Vector2 dir;
    public bool interactionFlag = false;
    public bool clearHandFlag = false;

    public Vector2 mouseMovement;
}
