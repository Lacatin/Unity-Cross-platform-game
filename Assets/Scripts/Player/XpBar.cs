using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{

    public Slider slider;

    public void SetXp(float amount)
    {
        slider.value = amount;
    }

    public void SetMaxXp(float amount)
    {
        slider.maxValue = amount;
    }
}
