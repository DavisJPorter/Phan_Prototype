using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JDATE
{


public class DestroyInteractible : InteractibleBase
{
        public override void OnInteract()
        {
            base.OnInteract();
            Destroy(gameObject);
        }
    }
}
