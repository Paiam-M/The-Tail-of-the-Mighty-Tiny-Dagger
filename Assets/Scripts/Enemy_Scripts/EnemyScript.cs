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
    private float faceCheck = 1;

    [Header("Enemy Attributes")]
    public float deathTimer = 2.5f;
    public Sprite deathState;
    public float eyesight = 3.0f;
    public int bodyDamage = 30;

    private SpriteRenderer sRend;


    // Use this for initialization
    void Start()
    {
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

        Debug.DrawRay(transform.position, Vector2.right, Color.white, 0, false);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, eyesight * faceCheck, mask);
        if (hit.collider != null && hit.collider.tag == "Player")
            target = hit.transform;
        else
            target = null;


        //if we see player, then chase, else patrol
        if (target == null)
            patrol();
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
            if (isMovingRight(transform.position, target.position))
            {
                sRend.flipX = true;
                faceCheck = 1;
            }
            else
            {
                sRend.flipX = false;
                faceCheck = -1;
            }
            Debug.Log("FOLLOWING PLAYER");
        }

        //Should change this but I'll leave it for now.
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
        {
            sRend.flipX = true;
            faceCheck = 1;
        }
        else
        {
            sRend.flipX = false;
            faceCheck = -1;
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerStats>().health -= bodyDamage;
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Debug.Log(Vector2.up * 10 + Vector2.right * 100 * faceCheck);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10 + Vector2.right * 100 * faceCheck, ForceMode2D.Force);
        }
    }

    IEnumerator Death()
    {
        print("I died!");
        DestroyObject(this.gameObject);
        yield return null;
    }

}