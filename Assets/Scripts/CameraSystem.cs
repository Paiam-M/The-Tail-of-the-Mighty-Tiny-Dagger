using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

    public GameObject player;
    

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");

	}
	
	// Update is called once per frame
	void LateUpdate () {

        if ((player.transform.position.x - transform.position.x) >= 3)
            transform.position = new Vector3(player.transform.position.x - 3, player.transform.position.y, -10);
        else if ((player.transform.position.x - transform.position.x) <= -3)
            transform.position = new Vector3(player.transform.position.x + 3, player.transform.position.y, -10);
    }
}
