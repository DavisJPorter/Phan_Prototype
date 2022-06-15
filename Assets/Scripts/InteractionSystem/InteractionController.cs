using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JDATE
{


public class InteractionController : MonoBehaviour
{
        [Header("Data")]
        public InteractionInputData interactionInputData;

        public InteractionData interactionData;

        [Space, Header("UI")]
        [SerializeField] private InteractionUIPanel uiPanel;

        [Space]
        [Header("Ray Settings")]
        public float rayDistance;
        public float raySphereRadius;
        public LayerMask interactibleLayer;

        private CharacterController fpsplayer;

        private bool i_interacting;
        private float i_holdTimer = 0f;

        private void Awake()
        {
            fpsplayer = FindObjectOfType<CharacterController>();
        }

        private void Update()
        {
            CheckForInteractible();
            CheckForInteractibleInput();
        }

        void CheckForInteractible()
        {
            Ray ray = new Ray(fpsplayer.transform.position,fpsplayer.transform.forward);
            RaycastHit hitInfo;

            bool hitInteractible = Physics.SphereCast(ray, raySphereRadius, out hitInfo, rayDistance, interactibleLayer);

            if (hitInteractible)
            {
                InteractibleBase _interactible = hitInfo.transform.GetComponent<InteractibleBase>();

                if (_interactible != null)
                {
                    if (interactionData.IsEmpty())
                    {
                        interactionData.Interactible = _interactible;
                        uiPanel.SetToolTip(_interactible.tooltipMessage);
                    }
                    else
                    {
                        if (!interactionData.IsSameInteractible(_interactible))
                        {
                               interactionData.Interactible = _interactible;
                            uiPanel.SetToolTip(_interactible.tooltipMessage);
                        }
                            
                            
                    }
                }
            }
            else
            {
                uiPanel.ResetUI();
                interactionData.ResetData();
            }

            Debug.DrawRay(ray.origin, ray.direction * rayDistance, hitInteractible ? Color.green : Color.red);
        }

        void CheckForInteractibleInput()
        {
            if (interactionData.IsEmpty())
                return;

            if (interactionInputData.InteractClick)
            {
                i_interacting = true;
                i_holdTimer = 0f;
            }

            if (interactionInputData.InteractRelease)
            {
                i_interacting = false;
                i_holdTimer = 0f;
                uiPanel.UpdateProgressBar(0f);
            }

            if (i_interacting)
            {
                if (!interactionData.Interactible.IsInteractable)
                    return;

                if (interactionData.Interactible.HoldInteract)
                {
                    i_holdTimer += Time.deltaTime;

                    float holdMeter = i_holdTimer / interactionData.Interactible.HoldDuration;
                    uiPanel.UpdateProgressBar(holdMeter);

                    if(holdMeter > 1f)
                    {
                        interactionData.Interact();
                        i_interacting = false;
                    }
                }
                else
                {
                    interactionData.Interact();
                    i_interacting = false;
                }
            }
        }
    }
}
