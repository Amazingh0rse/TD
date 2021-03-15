using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // now I can use the slider component

public class HealthBar : MonoBehaviour
{
    // Making things public to be able to call them from outside
    // Variable to store the slider
    public Slider slider;
    // Making a gradient to be able to change color depending on the player health
    public Gradient gradient;
    // To change the fill color in the health bar
    public Image fill; 
    
    // Sets the max health so I don't have to do it in Unity all the time
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        // Value 1 is all the way to the right on the slider
        // And 0 all the way to the left
        fill.color = gradient.Evaluate(1f);
    }

    // Setting the health to the slider
    public void SetHealth(int health)
    {
        slider.value = health;
        // Dynamic use of set health and since the value is between 0-1 I am using
        // normalizedValue and not value
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }


}
