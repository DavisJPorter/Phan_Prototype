using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JDATE
{


public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float walkSpeed = 3f;
    public float sprintSpeed = 6f;
    public float crouchSpeed = 1f;
    public float currentSpeed;
    public float gravity = -9.81f;
    public float jumpHeight = 1f;
    public float playerStamina = 100.0f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool sprintAble = true;

    private bool isCrouching;
    private Vector3 originalCenter;
    private float originalHeight;
    private float originalMoveSpeed;

    void Start()
    {
        transform.tag = "Player"; 
        controller = GetComponent<CharacterController>();
        originalCenter = controller.center;
        originalHeight = controller.height;
        originalMoveSpeed = walkSpeed;
        currentSpeed = originalMoveSpeed;
    }
    void Update()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            controller.height = 1f;
            controller.center = new Vector3(0f, -0.3f, 0f);
            currentSpeed = crouchSpeed;
            isCrouching = true;
        }

        if (!Input.GetButton("Crouch") && isCrouching)
        {   
            currentSpeed = originalMoveSpeed;
            controller.height = originalHeight;
            controller.center = originalCenter;
            isCrouching = false;            
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * walkSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetButtonDown("Run") && sprintAble)
        {
            currentSpeed = sprintSpeed;
            sprintAble = false;
        }
        else if (Input.GetButtonUp("Run"))
        {
            currentSpeed = walkSpeed;
            sprintAble = true;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        controller.Move(move * currentSpeed * Time.deltaTime);
    }

}
}
