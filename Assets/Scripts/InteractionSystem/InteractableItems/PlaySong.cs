using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JDATE
{



public class PlaySong : InteractibleBase
{
        public GameObject item;
        public AudioSource playSound;
        public override void OnInteract()
        {
            base.OnInteract();
            playSound.Play();
            Destroy(item);
        }
    }
}
