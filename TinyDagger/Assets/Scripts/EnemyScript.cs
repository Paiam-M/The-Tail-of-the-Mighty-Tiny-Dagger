using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public float speed;
    public float startWaitTime;
    public Transform[] moveSpots;

    private Transform target;
    private int randSpot;
    private float waitTime;

	// Use this for initialization
	void Start ()
    {
        target = null;
        randSpot = Random.Range(0, moveSpots.Length);
        waitTime = startWaitTime;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if we see player, then chase, else patrol
        if (target == null)
            patrol();
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
            Debug.Log("FOLLOWING PLAYER");
        }

    }

    //patrol around the platform. stop at points on the floor, and wait some time before moving again
    private void patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(moveSpots[randSpot].position.x, transform.position.y), speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.x - moveSpots[randSpot].position.x) < 0.2f)
        {
            if (waitTime <= 0f)
            {
                randSpot = Random.Range(0, moveSpots.Length);                
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
