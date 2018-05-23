using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public int health;
    public int armor;
    public Slider healthSlider;
    public Slider armorSlider;

    void Start()
    {
        health = 100;
        armor = 20;

        healthSlider.maxValue = health;
        healthSlider.value = health;
        armorSlider.maxValue = armor;
        armorSlider.value = armor;
    }

    void Update()
    {
        armorSlider.value = armor;
        healthSlider.value = health;
    }
}
