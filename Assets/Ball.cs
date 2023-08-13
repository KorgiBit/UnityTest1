using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    private Rigidbody ballRigidbody;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;

    private float jumpForce = 5f;
    public float moveSpeed = 5f;

    
    private void Awake()
    {
        ballRigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Ball.Enable();
        playerInputActions.Ball.Jump.performed += Jump;
        
        
    }
        

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump " + context.phase);
        if ( context.performed)
        {
            ballRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = playerInputActions.Ball.Move.ReadValue<Vector2>();
        ballRigidbody.AddForce(new Vector3(direction.x, 0, direction.y) * moveSpeed, ForceMode.Force);
    }
}
