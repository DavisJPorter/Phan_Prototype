using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_is_Back : MonoBehaviour
{
    public CharacterController tallMan;
    public CharacterController ballMan;
    public Camera tallCam;
    public Camera ballCam;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        tallCam.enabled = true;
        ballCam.enabled = false;
        tallMan.enabled = true;
        ballMan.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ball();
    }

    public void Ball()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            tallCam.enabled = !tallCam.enabled;
            ballCam.enabled = !ballCam.enabled;
            tallMan.enabled = !tallMan.enabled;
            ballMan.enabled = !ballMan.enabled;
        }
    }
}
