using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manaBar : MonoBehaviour
{
    public static manaBar instance;

    public Slider slider;
    public Gradient gradient;
    public Image Fill;

    private void Awake()
    {
        instance = this;
    }


    public void setMaxMana(int Mana)
    {
        slider.maxValue = Mana;
        slider.value = Mana;
        Fill.color = gradient.Evaluate(1f);
    }
    public void SetMana(int Mana)
    {
        slider.value = Mana;
        Fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    // Start is called before the first frame update
    void Start()
    {
        Fill.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
