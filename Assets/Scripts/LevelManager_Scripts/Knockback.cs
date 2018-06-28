using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {

    public GameObject player;
    public float power;

    public int time;
    private Vector2 currentCounterDirection;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update ()
    {
        if (time == 5)
            currentCounterDirection = -player.GetComponent<Rigidbody2D>().velocity;

        if (time > 0)
        {
            Debug.Log("Hit");
            player.GetComponent<Rigidbody2D>().AddForce(currentCounterDirection * power);
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
