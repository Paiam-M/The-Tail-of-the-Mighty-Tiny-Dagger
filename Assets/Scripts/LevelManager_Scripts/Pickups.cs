using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour {

   
    public int containedHealth = 0;
    public int containedArmor = 0;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            collider.GetComponent<PlayerStats>().health += containedHealth;
            collider.GetComponent<PlayerStats>().armor += containedArmor;

            Destroy(gameObject);
        }
    }
}
