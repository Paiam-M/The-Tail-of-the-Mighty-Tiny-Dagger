using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int health;
    public int armor;

    void Start()
    {
        health = 100;
        armor = 20;
    }
}
