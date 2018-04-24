using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public float horizontalSpeed = 3.0f;
    public float jumpPower = 5.0f;
    private float moveVelocity;

    float h;
    float v;
	// Update is called once per frame
	void FixedUpdate ()
    {
        h = horizontalSpeed * Input.GetAxis("Horizontal");
        //v = verticalSpeed * Input.GetAxis("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2( h, GetComponent<Rigidbody2D>().velocity.y );

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2( GetComponent<Rigidbody2D>().velocity.x, jumpPower );
        }
	}
}
