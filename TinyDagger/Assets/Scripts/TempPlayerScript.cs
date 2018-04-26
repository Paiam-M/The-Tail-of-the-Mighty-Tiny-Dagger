using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerScript : MonoBehaviour {

    public int speed;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        rb = this.GetComponent<Rigidbody2D>();
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
}
