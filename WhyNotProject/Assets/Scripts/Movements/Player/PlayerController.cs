using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerCamera = null;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float mouseSensityvity = 4.0f;
    [SerializeField][Range(0.0f, 0.05f)] private float moveSmoothTime = 0.3f;
    [SerializeField] private float walkSpeed = 2.0f;
    [SerializeField] private float jumpForce = 2.0f;
    [SerializeField] private float standHeight = 2.0f;
    [SerializeField] private float crouchHeight = 0.9f;

    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode crouchKey = KeyCode.C;

    private float cameraPitch = 0.0f;
    private float velocityY = 0.0f;

    private bool canJump = true;
    private bool canCamera = true;

    private Vector2 currentDir = Vector2.zero;
    private Vector2 currentDirVelocity = Vector2.zero;

    private CharacterController characterController;

    private LockedCursorController cursor;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        cursor = GameObject.Find("LockedCursor").GetComponent<LockedCursorController>();
    }

    private void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
    }

    private void LateUpdate()
    {
        Crouching();
    }

    private void UpdateMouseLook()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canCamera = !canCamera;
            cursor.Esc = !canCamera;
        }

        if (canCamera != false)
        {
            Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            cameraPitch -= mouseDelta.y * mouseSensityvity;
            cameraPitch = Mathf.Clamp(cameraPitch, -80, 80);

            playerCamera.localEulerAngles = Vector3.right * cameraPitch;
            transform.Rotate(Vector3.up * mouseDelta.x * mouseSensityvity);
        }
    }

    private void UpdateMovement()
    {
        Vector2 targetDir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if (characterController.isGrounded == true) velocityY = 0.0f;

        if (Physics.Raycast(transform.position, Vector3.down, characterController.bounds.extents.y + 0.1f) || characterController.isGrounded == true)
        {
            if (Input.GetKeyDown(jumpKey) && canJump == true)
            {
                velocityY = jumpForce;
            }
        }

        velocityY += gravity * Time.deltaTime;
        

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * velocityY;

        characterController.Move(velocity * Time.deltaTime);
    }

    private void Crouching()
    {
        if (Input.GetKey(crouchKey))
        {
            characterController.height = crouchHeight;
            canJump = false;
        }
        else
        {
            characterController.height = standHeight;
            canJump = true;
        }
    }

    private void Zoom()
    {

    }
}
