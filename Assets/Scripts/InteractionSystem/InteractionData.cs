using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JDATE
{
    [CreateAssetMenu(fileName = "Interaction Data", menuName = "InteractionSystem/InteractionData")]
public class InteractionData : ScriptableObject
 {
        private InteractibleBase i_interactible;
        
        public InteractibleBase Interactible
        {
            get => i_interactible;
            set => i_interactible = value;
        }

        public void Interact()
        {
            i_interactible.OnInteract();
            ResetData();
        }

        public bool IsSameInteractible(InteractibleBase _newInteractible) => i_interactible == _newInteractible;
        public bool IsEmpty() => i_interactible == null;
        public void ResetData() => i_interactible = null;

        

 }
}
