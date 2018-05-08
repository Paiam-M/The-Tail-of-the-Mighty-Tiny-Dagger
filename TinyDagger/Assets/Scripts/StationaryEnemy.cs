using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemy : MonoBehaviour {

    private Transform target;

    private SpriteRenderer sRend;
    public float health = 10f;
    public float armor = 0f;
    public GameObject projectile;

    // Use this for initialization
    void Start ()
    {
        target = null;
        sRend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (target != null)
        {
            if (transform.position.x < target.position.x)
                sRend.flipX = true;
            else
                sRend.flipX = false;
            //check if the player is touching the enemy
            if (Vector2.Distance(transform.position, target.position) < 2f)
            {
                //player takes damage
            }
        }
	}

    public void takeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            //just die
            Destroy(gameObject);
        }
    }

    private void Fire()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }

    //if player has entered enemy range, set target to player
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            target = collider.transform;
        }
    }

    //if player has exited, set target to null
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            target = null;
        }
    }

}
