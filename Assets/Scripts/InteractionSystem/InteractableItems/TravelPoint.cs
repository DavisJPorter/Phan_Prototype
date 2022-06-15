using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JDATE
{


public class TravelPoint : InteractibleBase
{
    GameManager gm;

    public int nextLevel;    
        public override void OnInteract()
        {
            base.OnInteract();
            gm.LoadNextLevel(nextLevel);
        }

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        
    }
}
}
