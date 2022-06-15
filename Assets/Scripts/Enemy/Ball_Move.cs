using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Move : MonoBehaviour
{
    public CharacterController controller;
    public float regSpeed = 6f;
    public float topSpeed = 10f;
    public float currentSpeed;
    private bool sprintAble;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * regSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Run") && sprintAble)
        {
            currentSpeed = topSpeed;
            sprintAble = false;
        }
        else if (Input.GetButtonUp("Run"))
        {
            currentSpeed = regSpeed;
            sprintAble = true;
        }
        controller.Move(velocity * Time.deltaTime);
        controller.Move(move * currentSpeed * Time.deltaTime);
    }
}
