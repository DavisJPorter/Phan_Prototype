using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JDATE
{


public class InteractibleBase : MonoBehaviour, IInteractable
{
        #region Variables

        [Header("Interactable Settings")]
        public float holdDuration;

        [Space]
        public bool holdInteract;
        public bool multipleUse;
        public bool isInteractable;
        [SerializeField] private string TooltipMessage = "Interact";

        public float HoldDuration => holdDuration;

        #endregion

        #region Properties
        public bool HoldInteract => holdInteract;
        public bool MultipleUse => multipleUse;
        public bool IsInteractable => isInteractable;

        public string tooltipMessage => TooltipMessage;

        #endregion

        #region Methods

        public virtual void OnInteract()
        {
            Debug.Log("INTERACTED: " + gameObject.name);
        }
        #endregion
 }
}
