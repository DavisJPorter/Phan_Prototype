using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JDATE
{


public class FlashLightBattery : InteractibleBase
{

    public GameObject battery;
    public override void OnInteract()
    {
        {
            base.OnInteract();
            FlashlightController flashlight = GameObject.FindGameObjectWithTag("Flashlight").gameObject.GetComponent<FlashlightController>();
            flashlight.batteryCount += 1;
            Destroy(battery);
        }
    }
}
}
