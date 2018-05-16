using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthDmg : MonoBehaviour {

    public Image healthBar;
    public float health = 10f;
    private float currHealth; //used for the enemy health bar
    public float armor = 0f;

    private SpriteRenderer sRend;

    private Rigidbody2D rb;
    private float forceSubtract = .2f;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
        currHealth = health;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(rb.velocity.x > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x - forceSubtract, 0f);
        }
	}

    public void takeDamage(float dmg)
    {
        health -= dmg;
        healthBar.fillAmount = health / currHealth;
        //knockback a short distance NOT PHYSICS
        knockBack();
        if (health <= 0)
        {
            //die die die
            //maybe make a death animation later on
            Destroy(gameObject);
        }
    }

    //implement if the enemy is on edge, dont knockback off the edge. like maplestory
    private void knockBack()
    {
        if (sRend.flipX)
        {
            Vector2 force = new Vector2(-5f, 0f);
            rb.velocity = force;
        }
        else
        {
            Vector2 force = new Vector2(5f, 0f);
            rb.velocity = force;
        }
    }

    //if player has entered enemy range, set target to player
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            //call takedamage on player
        }
    }
}
