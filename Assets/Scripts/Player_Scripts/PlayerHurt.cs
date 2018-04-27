using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{

    public LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "Player")
        {
            if (other.GetComponent<PlayerStats>().armor > 0)
                other.GetComponent<PlayerStats>().armor = other.GetComponent<PlayerStats>().armor - 10;
            else if (other.GetComponent<PlayerStats>().armor <= 0)
                other.GetComponent<PlayerStats>().health = other.GetComponent<PlayerStats>().health - 10;
        }
    }
}