using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerCamera = null;
    [SerializeField] private float mouseSensityvity = 4.0f;
    [SerializeField] private float walkSpeed = 2.0f;
    [SerializeField] private float jumpForce = 2.0f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField][Range(0.0f, 0.05f)] private float moveSmoothTime = 0.3f;

    private float cameraPitch = 0.0f;
    private float velocityY = 0.0f;
    private CharacterController characterController;

    private Vector2 currentDir = Vector2.zero;
    private Vector2 currentDirVelocity = Vector2.zero;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
    }

    private void UpdateMouseLook()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        cameraPitch -= mouseDelta.y * mouseSensityvity;
        cameraPitch = Mathf.Clamp(cameraPitch, -80, 80);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * mouseDelta.x * mouseSensityvity);
    }

    private void UpdateMovement()
    {
        Vector2 targetDir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if (characterController.isGrounded == true) velocityY = 0.0f;

        if (characterController.isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            velocityY = jumpForce;
        }

        velocityY += gravity * Time.deltaTime;
        

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * velocityY;

        characterController.Move(velocity * Time.deltaTime);
    }

    private void Zoom()
    {

    }
}
