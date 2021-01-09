using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AltitudeBar : MonoBehaviour
{
    public Slider slider;
   
    public void SetMaxAltitude(float altitude)
    {
        slider.maxValue = altitude;
        slider.value = altitude;
    }
    public void SetAltitude(float altitude)
    {
        slider.value = altitude;
    }
}
