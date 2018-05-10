using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemy : MonoBehaviour {

    private GameObject target;

    private SpriteRenderer sRend;
    public float health = 10f;
    public float armor = 0f;
    public GameObject projectile;

    public float defaultFireTime = 5f;
    private float fireTime;

    // Use this for initialization
    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        sRend = GetComponent<SpriteRenderer>();
        fireTime = defaultFireTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (target != null)
        {
            if (transform.position.x < target.transform.position.x)
                sRend.flipX = true;
            else
                sRend.flipX = false;
            if(Vector2.Distance(transform.position, target.transform.position) < 10f && fireTime <= 0f)
            {
                Fire();
                fireTime = defaultFireTime;
            }
        }
        if (fireTime >= 0)
        {
            fireTime -= Time.deltaTime;
        }
	}

    public void takeDamage(float dmg)
    {
        health -= dmg;
        knockBack();
        if (health <= 0)
        {
            //just die
            Destroy(gameObject);
        }
    }

    //implement if the enemy is on edge, dont knockback off the edge. like maplestory
    private void knockBack()
    {
        if (sRend.flipX)
        {
            Vector2 knock = new Vector2(transform.position.x - 5f, Random.Range(transform.position.y, transform.position.y + 5f));
            transform.position = Vector2.MoveTowards(transform.position, knock, 10f);
        }
        else
        {
            Vector2 knock = new Vector2(transform.position.x + 5f, Random.Range(transform.position.y, transform.position.y + 5f));
            transform.position = Vector2.MoveTowards(transform.position, knock, 10f);
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
            //player takes damage
        }
    }

}
