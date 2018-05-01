using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : NPC
{

    [Header("Enemy Movement")]
    public float speed;
    public float startWaitTime;
    public float minX;
    public float maxX;
    public LayerMask mask;

    private Transform target;
    public Transform moveSpot;
    private float waitTime;

    [Header("Enemy Attributes")]
    public float deathTimer = 2.5f;
    public Sprite deathState;
    //public int health = 10;
    //public float armor = 0f;
    //public bool isEnemy = true;

    private SpriteRenderer sRend;


    // Use this for initialization
    void Start()
    {
        hitPoints = 10;
        armor = 0;
        isEnemy = true;
        target = null;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), transform.position.y);
        waitTime = startWaitTime;
        sRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoints <= 0)
            StartCoroutine(Death());

        //if we see player, then chase, else patrol
        if (target == null)
            patrol();
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
            if (isMovingRight(transform.position, target.position))
                sRend.flipX = true;
            else
                sRend.flipX = false;
            Debug.Log("FOLLOWING PLAYER");
        }

        if (transform.position.y < -10)
        {
            StartCoroutine(Death());
        }
    }

    //patrol around the platform. stop at points on the floor, and wait some time before moving again
    private void patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
        if (isMovingRight(transform.position, moveSpot.position))
            sRend.flipX = true;
        else
            sRend.flipX = false;
        if (Mathf.Abs(transform.position.x - moveSpot.position.x) < 0.2f)
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

    private bool isMovingRight(Vector2 pos, Vector2 newPos)
    {
        if ((pos.x - newPos.x) >= 0)
            return false;
        else
            return true;
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

    IEnumerator Death()
    {
        print("I died!");
        DestroyObject(this.gameObject);
        yield return null;
    }

}