using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 10.0f;
    public float jumpSpeed = 300.0f;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround; //to detect what the base of the player is touching

    private bool grounded;
    private bool midJump;
    public AudioSource jumpSFX;

    public int front = 1;  //direction player is facing

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }


    void Update () {
        float x = Input.GetAxis("Horizontal") * speed;
        float y = Input.GetAxis("Vertical") * jumpSpeed;
        x *= Time.deltaTime;
        y *= Time.deltaTime;

        if (x < 0)
            front = -1;
        else
            front = 1;

        if (grounded)
            midJump = false;

        rb.AddForce(new Vector2(x, 0));
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            Jump(rb);

        if (Input.GetKeyDown(KeyCode.Space) && !grounded && !midJump)
        {
            Jump(rb);
            midJump = !midJump;
        }
	}

    void Jump(Rigidbody2D rb)
    {
        jumpSFX.Play();
        rb.AddForce(Vector2.up * jumpSpeed);
    }

}
