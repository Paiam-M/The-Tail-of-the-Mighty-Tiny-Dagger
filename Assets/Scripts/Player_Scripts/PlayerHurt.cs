using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    public int damage;
    public GameObject player;
    public LevelManager levelManager;

    void Start()
    {
        player = GameObject.Find("Player");
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerStats>().health <= 0)
        {
            levelManager.RespawnPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "Player")
        {
            if (other.GetComponent<PlayerStats>().armor > 0)
            {
                if (other.GetComponent<PlayerStats>().armor - damage < 0)
                {
                    int tempDamage = damage - other.GetComponent<PlayerStats>().armor;
                    other.GetComponent<PlayerStats>().armor = 0;
                    other.GetComponent<PlayerStats>().health -= tempDamage;
                }
                else
                {
                    other.GetComponent<PlayerStats>().armor -= damage;
                }
            }
            else if (other.GetComponent<PlayerStats>().armor <= 0 && other.GetComponent<PlayerStats>().health - damage > 0)
                other.GetComponent<PlayerStats>().health -= damage;
            else
                other.GetComponent<PlayerStats>().health = 0;
        }
    }
}