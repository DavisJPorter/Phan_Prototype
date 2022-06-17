using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JDATE
{


public class Ball_Move : MonoBehaviour
{
    public CharacterController controller;

    public float regSpeed = 6f;
    public float topSpeed = 10f;
    public float currentSpeed;
    private bool sprintAble;

    Vector3 velocity;
    
    public bool inHand = false;

    public CharacterController tallMan;
    public CharacterController ballMan;
    public Camera tallCam;
    public Camera ballCam;

    public GameObject player;
    public GameObject hand;
    public GameObject body;

    public float damage = 25f;
    public float range = 1f;

        void Start()// Start is called before the first frame update
    {
        hand.SetActive(true);
        body.SetActive(false);
        inHand = true;
        tallCam.enabled = true;
        tallMan.enabled = true;
        ballCam.enabled = false;
        ballMan.enabled = false;
    }
        
    void Update() // Update is called once per frame
    {
        Ball();
        Attack();
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

    public void Ball()
    {
        if (Input.GetKey(KeyCode.X))
        {
            inHand = false;
            tallMan.enabled = false;
            tallCam.enabled = false;
            ballMan.enabled = true;
            ballCam.enabled = true;
            hand.SetActive(false);
            body.SetActive(true);
        }
        else 
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Time.deltaTime * 40);
            tallMan.enabled = true;
            ballMan.enabled = false;
            tallCam.enabled = true;
            ballCam.enabled = false;
            inHand = true;
            hand.SetActive(true);
            body.SetActive(false);    
        }
                
        
    }
        public void Attack()
        {
            RaycastHit hit;
            if (Physics.Raycast(ballMan.transform.position, ballMan.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.takeDamage(damage);
                }
            }
        }
}
}

