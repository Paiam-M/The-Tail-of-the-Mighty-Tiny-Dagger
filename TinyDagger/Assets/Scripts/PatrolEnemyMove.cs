using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatrolEnemyMove : MonoBehaviour {

    public float speed;
    public float startWaitTime;
    public Transform moveSpot;

    private GameObject target;
    private float waitTime;
    public float minX;
    public float maxX;

    private SpriteRenderer sRend;
    public float findDistance = 5f;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), transform.position.y);
        sRend = GetComponent<SpriteRenderer>();
        //currHealth = health;
    }

    // Update is called once per frame
    //this code is so unorganized
    void Update()
    {
        if (target == null) return;
        Vector2 targetPos = target.transform.position;
        //if we see player, then chase, else patrol
        float distance = targetPos.x - transform.position.x;
        //if facing right, chase player right
        if (sRend.flipX && (distance < findDistance && distance >= 0f))
        {
            //so we arent directly on top of the player
            Vector2 newPos = new Vector2(targetPos.x - .5f, targetPos.y);
            transform.position = Vector2.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
            Debug.Log("FOLLOWING PLAYER RIGHT");
        }
        //facing left
        else if (!sRend.flipX && (distance > -findDistance && distance <= 0f))
        {
            Vector2 newPos = new Vector2(targetPos.x + .5f, targetPos.y);
            transform.position = Vector2.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
            Debug.Log("FOLLOWING PLAYER LEFT");
        }
        else
        {
            //flip image based on where ur chasing
            if (distance >= 0f)
                sRend.flipX = true;
            else if (distance <= 0f)
                sRend.flipX = false;
        }
        if (distance >= findDistance || distance <= -findDistance)
            patrol();
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

}
