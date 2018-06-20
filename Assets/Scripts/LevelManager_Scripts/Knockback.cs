using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {

    public GameObject player;
    public float power;

    private int time;
	
	// Update is called once per frame
	void Update ()
    {
        if (time > 0)
        {
            Debug.Log("Hit");
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * power);
            time--;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            time += 5;
        }
    }
}
