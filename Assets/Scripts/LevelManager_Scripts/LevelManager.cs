using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    public PlayerController player;

	void Start ()
    {
        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RespawnPlayer()
    {
        player.transform.position = currentCheckpoint.transform.position;
        Debug.Log("Player Respawn");
        //player.transform.position = currentCheckpoint.transform.position;
    }
}
