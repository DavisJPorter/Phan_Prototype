using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace JDATE
{



public class FlashlightUIBar : MonoBehaviour
{
    [SerializeField] private Image flashlightBar;

    public void UpdateProgressBar(float fillAmount)
    {
        flashlightBar.fillAmount = fillAmount;
    }

    public void ResetUI()
    {
        flashlightBar.fillAmount = 0f;
    }
}
}