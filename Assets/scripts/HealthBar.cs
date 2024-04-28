using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public static HealthBar instance;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private void Awake()
    {
        instance = this;
    }
    public void setMaxHealth(int health)
    {
        slider.maxValue = health;//slide the image that represent the color and gradient of the player health.
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
    public void setHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        fill.color = gradient.Evaluate(1f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
