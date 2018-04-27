using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public Checkpoint currentCheckpoint;
    public GameObject player;

	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RespawnPlayer()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Player Respawn");
        //player.transform.position = currentCheckpoint.transform.position;
    }
}
