using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    public float speed;
    public int damage = 5;
    private Transform player;
    private Vector2 target;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target) < 0.2f)
        {
            Destroy(gameObject);
        }
	}

    public void DamagePlayer()
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
                player.GetComponent<PlayerStats>().armor -= damage;
        }
        else if (player.GetComponent<PlayerStats>().armor <= 0 && player.GetComponent<PlayerStats>().health - damage > 0)
            player.GetComponent<PlayerStats>().health -= damage;
        else
            player.GetComponent<PlayerStats>().health = 0;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            DamagePlayer();
            Destroy(gameObject);
        }
    }
}
