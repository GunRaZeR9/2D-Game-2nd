using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{   
    #region Computed_Fields
    public Slider slider;
    public Gradient gradient;
    public Image Fill;
    #endregion

    #region Setter_Atributes
    public void setMaxHealth(float health){
        slider.maxValue = health;
        slider.value = health;

        Fill.color = gradient.Evaluate(1f);
    }

    public void setHealth(float health){
        slider.value = health;

        Fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    #endregion
}
