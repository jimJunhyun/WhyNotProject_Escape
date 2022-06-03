using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    private float gravity = -9.8f;
    private Vector3 moveDirection;

    [SerializeField]
    private Transform cameraTrasform;
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (characterController.isGrounded == false)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        Vector3 movedis = cameraTrasform.rotation * direction;
        moveDirection = new Vector3(movedis.x, moveDirection.y, movedis.z);
    }
}
