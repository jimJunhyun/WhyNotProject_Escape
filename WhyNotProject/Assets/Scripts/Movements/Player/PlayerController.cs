using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerCamera = null;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float mouseSensityvity = 4.0f;
    [Range(0.0f, 0.05f)]
    [SerializeField] private float moveSmoothTime = 0.3f;
    [SerializeField] private float walkSpeed = 2.0f;
    [SerializeField] private float jumpForce = 2.0f;
    [SerializeField] private float standHeight = 2.0f;
    [SerializeField] private float crouchHeight = 0.9f;

    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode crouchKey = KeyCode.C;

    private float cameraPitch = 0.0f;
    private float velocityY = 0.0f;

    private bool crouching;
    private bool canJump = true;
    private bool canCamera = true;

    private Vector2 currentDir = Vector2.zero;
    private Vector2 currentDirVelocity = Vector2.zero;

    private CharacterController characterController;

    [HideInInspector]
    public LockedCursorController cursor;


    private void Start()
    {
        
        characterController = GetComponent<CharacterController>();
        cursor = GameObject.Find("LockedCursor").GetComponent<LockedCursorController>();
        characterController.center = new Vector3(0, 0, 0);
        playerCamera.transform.position = new Vector3(transform.position.x, transform.position.y + characterController.height / 1.5f, transform.position.z);
    }

    private void Update()
    {
        UpdateMouseLook();
        UpdateMovement();

        crouching = Input.GetKey(crouchKey);
    }

    private void FixedUpdate()
    {
        float desiredHeight = crouching ? crouchHeight : standHeight;

        if (characterController.height != desiredHeight)
        {
            Crouch(desiredHeight);

            var camPos = playerCamera.transform.position;
            camPos.y = transform.position.y + characterController.height / 1.5f;

            playerCamera.transform.position = camPos;
        }
        
    }


    private void UpdateMouseLook()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.O))
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

        if (characterController.isGrounded == true)
        {
            velocityY = -1f;
        }

        if (Input.GetKeyDown(jumpKey) && canJump == true)
        {
            Jump();
        }

        velocityY += gravity * Time.deltaTime;
        
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * velocityY;

        characterController.Move(velocity * Time.deltaTime);
    }

    private void Jump()
	{
        if (characterController.isGrounded == true)
        {
            velocityY = jumpForce;
        }
    }

    private void Crouch (float height)
    {
        float center = 0;

        characterController.height = Mathf.Lerp(characterController.height, height, 0.2f);
        characterController.center = Vector3.Lerp(characterController.center, new Vector3(0, center, 0), 0.2f);
    }
}
