using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5.0f;

    [SerializeField]
    float gravity = 9.8f;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    float rotateDamp = 0.2f;

    Vector3 inputVector;
    Vector3 moveDirection;
    Vector3 lastDirection;
    Vector3 velocity;

    CharacterController characterController;

    void Awake()
    {
        Initialize();
    }

    void Update()
    {
        InputHandler();
        MovementHandler();
    }

    void LateUpdate()
    {
        FacingHandler();
    }

    void Initialize()
    {
        characterController = GetComponent<CharacterController>();
    }

    void InputHandler()
    {
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");
    }

    void MovementHandler()
    {
        if (moveDirection != Vector3.zero)
        {
            lastDirection = moveDirection;
        }

        moveDirection.x = inputVector.x;
        moveDirection.z = inputVector.y;

        if (moveDirection.magnitude > 1.0f)
        {
            moveDirection = moveDirection.normalized;
        }

        velocity = moveDirection * moveSpeed;
        velocity.y -= gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }

    void FacingHandler()
    {
        Quaternion lookRotation = Quaternion.LookRotation(lastDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotateDamp);
    }
}

