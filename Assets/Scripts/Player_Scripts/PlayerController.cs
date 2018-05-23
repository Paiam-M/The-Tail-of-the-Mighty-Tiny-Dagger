using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 10.0f;
    public float jumpSpeed = 300.0f;
    public LayerMask mask = -1; //used for detection of basic melee strike

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround; //to detect what the base of the player is touching

    private bool grounded;
    private bool midJump;

    private int front = 1;  //direction player is facing

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
            DoubleJump(rb);
            midJump = !midJump;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
            meleeAttack();

        
	}

    BoxCollider2D meleeAttack()
    {
        print("Firing.\n");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * front, 3.0f, mask);
        if (hit.collider.tag == ("Enemy"))
        {
            NPC target = hit.collider.gameObject.GetComponent<NPC>();
            if (target.isEnemy == true)
            {
                target.takeDamage(5);
                print("Enemy hit!");
            }
            else
                print("Bonk!");
        }
    }

    void Jump(Rigidbody2D rb)
    {
        rb.AddForce(Vector2.up * jumpSpeed);
    }

    void DoubleJump(Rigidbody2D rb)
    {
        rb.AddForce(Vector2.up * (jumpSpeed / 2));
    }

}
