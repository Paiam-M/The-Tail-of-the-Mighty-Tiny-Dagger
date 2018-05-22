using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthDmg : MonoBehaviour {

    public Image healthBar;
    public float health = 10f;
    private float currHealth; //used for the enemy health bar
    public float armor = 0f;
    public int damage = 5;

    private SpriteRenderer sRend;

    private Rigidbody2D rb;
    private float forceSubtract = .2f;

    private GameObject player;
    private bool startedDmg = false;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
        currHealth = health;
        player = null;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(rb.velocity.x > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x - forceSubtract, 0f);
        }
        if (player != null && !startedDmg)
        {
            StartCoroutine("damagePlayer");
            startedDmg = true;
        }
        else if (startedDmg && player == null)
        {
            startedDmg = false;
            StopCoroutine("damagePlayer");
        }
	}

    IEnumerator damagePlayer()
    {
        while(player != null)
        {
            if (player.GetComponent<PlayerStats>().armor > 0)
            {
                if (player.GetComponent<PlayerStats>().armor - damage < 0)
                {
                    int tempDamage = damage - player.GetComponent<PlayerStats>().armor;
                    player.GetComponent<PlayerStats>().armor = 0;
                    player.GetComponent<PlayerStats>().health -= tempDamage;
                }
                else
                {
                    player.GetComponent<PlayerStats>().armor -= damage;
                }
            }
            else if (player.GetComponent<PlayerStats>().armor <= 0 && player.GetComponent<PlayerStats>().health - damage > 0)
                player.GetComponent<PlayerStats>().health -= damage;
            else
                player.GetComponent<PlayerStats>().health = 0;

            yield return new WaitForSeconds(2f);
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
            player = collider.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player = null;
        }
    }
}
