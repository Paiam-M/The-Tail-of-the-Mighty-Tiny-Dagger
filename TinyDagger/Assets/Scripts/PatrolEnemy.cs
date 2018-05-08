using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//patrol enemy only patrols DOES NOT FOLLOW PLAYER
public class PatrolEnemy : MonoBehaviour {

    public float speed;
    public float startWaitTime;
    public Transform moveSpot;

    private Transform target;
    private float waitTime;
    public float minX;
    public float maxX;

    private SpriteRenderer sRend;

    public float health = 10f;
    public float armor = 0f;

    // Use this for initialization
    void Start()
    {
        target = null;
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), transform.position.y);
        sRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        patrol();
        /*
        //if we see player, then chase, else patrol
        if (target == null)
            patrol();
        
        else
        {
            
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
            if (transform.position.x < target.position.x)
                sRend.flipX = true;
            else
                sRend.flipX = false;
            Debug.Log("FOLLOWING PLAYER");
            
        }*/

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
                moveSpot.position = new Vector2(Random.Range(minX, maxX), transform.position.y);
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
        if (collider.tag == "Player")
        {
            //player takes damage
            //target = collider.transform;
        }
    }

}
