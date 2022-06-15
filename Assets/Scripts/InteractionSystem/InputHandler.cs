using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JDATE
{





public class InputHandler : MonoBehaviour
{
    #region Data
    public InteractionInputData interactionInputData;
        #endregion

        #region BuiltIn Methods
        void Start()
    {
            interactionInputData.Reset();
    }


    void Update()
    {
            GetInteractionInputData();
    }
        #endregion

        void GetInteractionInputData()
        {
            interactionInputData.InteractClick = Input.GetKeyDown(KeyCode.E);
            interactionInputData.InteractRelease = Input.GetKeyUp(KeyCode.E);
        }
    }
}