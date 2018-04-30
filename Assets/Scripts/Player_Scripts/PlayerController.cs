using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 5.0f;
    public float jumpSpeed = 300.0f;
    public LayerMask mask = -1; //used for detection of basic melee strike

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround; //to detect what the base of the player is touching
    private bool grounded;
    private bool midJump;

    private Animator anim;

    private int front = 1;  //direction player is facing

    private Rigidbody2D rb;
    void Start()
    {
        anim = GetComponent<Animator>();
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

        if (grounded)
            midJump = false;

        rb.velocity = new Vector2(x, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            Jump(rb,jumpSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && !grounded && !midJump)
        {
            Jump(rb,jumpSpeed/2);
            midJump = !midJump;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
            meleeAttack();

        anim.SetFloat("walkSpeed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) );
        anim.SetBool("isGrounded",grounded);

        //transform.Translate(x, 0, 0);
        //transform.Translate(0, y, 0);
	}

    void meleeAttack()
    {
        print("Firing.\n");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 3.0f, mask);
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

    void Jump(Rigidbody2D rb, float jSpeed)
    {
        rb.AddForce(Vector2.up * jSpeed);
    }

}
