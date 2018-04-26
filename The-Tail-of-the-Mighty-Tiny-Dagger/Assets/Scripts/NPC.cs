using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour {

    public int hitPoints;
    public int armor;
    public bool isEnemy;

    public void takeDamage(int damage)
    {
        hitPoints -= damage - armor;
    }
}
