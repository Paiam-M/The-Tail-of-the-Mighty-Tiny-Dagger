using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerScript : MonoBehaviour {

    public int speed;

    private Rigidbody2D rb;
    private CapsuleCollider2D col;

    public EnemyHealthDmg enemy;

	// Use this for initialization
	void Start ()
    {
        rb = this.GetComponent<Rigidbody2D>();
        col = this.GetComponent<CapsuleCollider2D>();
        col.enabled = false;
        enemy = null;
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!col.enabled) col.enabled = true;
            //col.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (enemy != null)
            {
                enemy.takeDamage(2);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(moveHorizontal, 0) * speed);
        /*
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-moveHorizontal, 0)*speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(moveHorizontal, 0) * speed);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<EnemyHealthDmg>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemy = null;
    }
}
