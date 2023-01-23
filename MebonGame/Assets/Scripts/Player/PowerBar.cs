using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxPower(float power)
    {
        slider.maxValue = power;
        slider.value = power;
    }
    public void SetPower(float power)
    {
        slider.value = power;
    }
}
