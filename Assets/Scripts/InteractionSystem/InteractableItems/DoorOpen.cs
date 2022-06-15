using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JDATE
{


public class DoorOpen : InteractibleBase
{
        public GameObject door;
    public override void OnInteract()
    {
            base.OnInteract();
            door.GetComponent<Animation>().Play();
            isInteractable = false;
    }
}
}
