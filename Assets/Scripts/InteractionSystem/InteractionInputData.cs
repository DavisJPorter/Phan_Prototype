using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JDATE
{



[CreateAssetMenu(fileName = "InteractionInputData", menuName = "InteractionSystem/InputData")]
public class InteractionInputData : ScriptableObject
{
    private bool interact_Clicked;
    private bool interact_Release;

    public bool InteractClick
    {
        get => interact_Clicked;
        set => interact_Clicked = value;
    }

    public bool InteractRelease
    {
        get => interact_Release;
        set => interact_Release = value;
    }

    public void Reset()
    {
        interact_Clicked = false;
        interact_Release = false;
    }
}
}
