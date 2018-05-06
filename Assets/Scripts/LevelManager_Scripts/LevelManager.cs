using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public Checkpoint currentCheckpoint;
    public GameObject player;

    private int initialHealth;
    private int initialArmor;

	void Start ()
    {
        player = GameObject.Find("Player");
        initialHealth = player.GetComponent<PlayerStats>().health;
        initialArmor = player.GetComponent<PlayerStats>().armor;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RespawnPlayer()
    {
        Debug.Log("Player Respawn");
        player.transform.position = currentCheckpoint.transform.position;
        player.GetComponent<PlayerStats>().health = initialHealth;
        player.GetComponent<PlayerStats>().armor = initialArmor;
    }
}
