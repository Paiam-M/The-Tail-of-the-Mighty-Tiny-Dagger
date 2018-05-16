using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this will be flying enemy
public class FlyingEnemy : MonoBehaviour {

    public float speed;
    public float startWaitTime;
    public Transform moveSpot;

    private Transform target;
    private float waitTime;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private SpriteRenderer sRend;
    public BoxCollider2D box;

    public float health = 10f;
    public float armor = 0f;

    // Use this for initialization
    void Start ()
    {
        target = null;
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        sRend = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if we see player, then chase, else patrol
        if (target == null)
            patrol();
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (transform.position.x < target.position.x)
                sRend.flipX = true;
            else
                sRend.flipX = false;
            //check if the player is touching the enemy
            if (Vector2.Distance(transform.position, target.position) < 2f)
            {
                //player takes damage
            }
            Debug.Log("FOLLOWING PLAYER");
        }

    }

    public void takeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            //die die die
            //maybe make a death animation later on
            Destroy(gameObject);
        }
    }

    //patrol around the platform. stop at points on the floor, and wait some time before moving again
    private void patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
        if (transform.position.x < moveSpot.position.x)
            sRend.flipX = true;
        else
            sRend.flipX = false;
        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0f)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    //if player has entered enemy range, set target to player
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            target = collider.transform;
        }
    }

    //if player has exited, set target to null
    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            target = null;
        }
    }

}
