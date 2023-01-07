using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public bool speedUp;
    private float gravityValue = -9.81f;

    [Header("Player Setting")]
    [Range(0, 10)]

    public float playerSpeed = 2.0f;
    public float speedUpValue = 1.2f;
    public float jumpHeigt = 1.0f;

    private void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        SpeedUp();
        Movement();
        Jump();
    }

    public void SpeedUp()
    {
        if(InputManager.Instance.PlayerInput.PlayerMain.SpeedUp.IsPressed())
        {
            speedUp = true;
        }
        else if(!InputManager.Instance.PlayerInput.PlayerMain.SpeedUp.IsPressed())
        {
            speedUp = false;
        }
    }

    public void Movement()
    {
        
        Vector3 movement = InputManager.Instance.PlayerInput.PlayerMain.Move.ReadValue<Vector2>();
        
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        
        if(speedUp)
        {
            controller.Move(move * Time.deltaTime * playerSpeed * speedUpValue);
        }
        else
        {
            controller.Move(move * Time.deltaTime * playerSpeed);
        }

        if(move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

    }

    public void Jump()
    {
        if(InputManager.Instance.PlayerInput.PlayerMain.Jump.IsPressed() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeigt * - 3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
