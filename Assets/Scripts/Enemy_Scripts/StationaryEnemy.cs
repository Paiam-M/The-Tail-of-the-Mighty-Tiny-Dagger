using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationaryEnemy : MonoBehaviour {

    private GameObject target;

    private SpriteRenderer sRend;

    public GameObject projectile;

    public float defaultFireTime = 5f;
    private float fireTime;

    //public Image healthBar;

    // Use this for initialization
    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        sRend = GetComponent<SpriteRenderer>();
        fireTime = defaultFireTime;
        //currHealth = health;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (target != null)
        {
            if (transform.position.x < target.transform.position.x)
                sRend.flipX = false;
            else
                sRend.flipX = true;
            if(Vector2.Distance(transform.position, target.transform.position) < 10f && fireTime <= 0f)
            {
                Fire();
                fireTime = defaultFireTime;
            }
        }
        if (fireTime >= 0)
        {
            fireTime -= Time.deltaTime;
        }
	}


    //implement. if the enemy is on edge, dont knockback off the edge. like maplestory
    private void knockBack()
    {
        if (sRend.flipX)
        {
            Vector2 knock = new Vector2(transform.position.x - 5f, Random.Range(transform.position.y, transform.position.y + 5f));
            transform.position = Vector2.MoveTowards(transform.position, knock, 10f);
        }
        else
        {
            Vector2 knock = new Vector2(transform.position.x + 5f, Random.Range(transform.position.y, transform.position.y + 5f));
            transform.position = Vector2.MoveTowards(transform.position, knock, 10f);
        }
    }

    private void Fire()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }

}
