using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
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
    public AudioSource jumpSFX;

    public float KnockbackCount = 0.0f;
    public float KnockbackPower = 5.0f;
    public bool isFacingLeft;
    public bool isFacingRight;

    //private int front = 1;  //direction player is facing
    private Animator animator;

    private GameObject pauseUI;
    private GameObject inventoryUI;

    private Rigidbody2D rb;

    void Start()
    {
        pauseUI = GameObject.Find("PauseCanvas");
        inventoryUI = GameObject.Find("InventoryCanvas");

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }


    void Update () {
        /*
        if (EventSystem.current.IsPointerOverGameObject())
        { return; }
        */
        float x = Input.GetAxis("Horizontal") * speed;
        float y = Input.GetAxis("Vertical") * jumpSpeed;
        x *= Time.deltaTime;
        y *= Time.deltaTime;

        animator.SetFloat("Speed", Mathf.Abs(x));
        animator.SetBool("facingLeft", isFacingLeft);
        animator.SetBool("facingRight", isFacingRight);
        //animator.speed = Mathf.Abs(x);

        if (x > 0 || Input.GetKey("d"))
        {
            isFacingRight = true; isFacingLeft = false;
        }
        else if (x < 0 || Input.GetKey("a"))
        {
            isFacingRight = false; isFacingLeft = true;
        }

        if (grounded)
            midJump = false;

        rb.velocity = new Vector2(x, rb.velocity.y);
        if (!pauseUI && !inventoryUI && Input.GetButtonDown("Jump") && grounded)
            Jump(rb, jumpSpeed);

        if (!pauseUI && !inventoryUI && Input.GetButtonDown("Jump") && !grounded && !midJump)
        {
            Jump(rb, (jumpSpeed / 1.5f));
            midJump = !midJump;
        }

        if (KnockbackCount <= 0)
        {
            x = Input.GetAxis("Horizontal") * speed;
        }
        else
        {
            if (isFacingRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-KnockbackPower, KnockbackPower);
                KnockbackCount -= 0.1f;
            }
            else if (isFacingLeft)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(KnockbackPower, KnockbackPower);
                KnockbackCount -= 0.1f;
            }
        }
	}

    /*
    void meleeAttack()
    {
        PlayerBasicAttack attackComponent = gameObject.transform.GetChild(3).GetComponent<PlayerMeleeBasic>();
        print("Firing.\n");
        attackComponent.attackTime = attackComponent.maxAttackTime;
        //gameObject.transform.GetChild(2).GetComponent<PlayerShootBasic>().throwTime = gameObject.transform.GetChild(2).GetComponent<PlayerShootBasic>().maxThrowTime;
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 3.0f, mask);
        if (hit.collider)
        {
            EnemyHealthDmg target = hit.collider.gameObject.GetComponent<EnemyHealthDmg>();
            target.takeDamage(5);
            print("Enemy hit!");

        }
    }
    */

    void Jump(Rigidbody2D rb, float jSpeed)
    {
        jumpSFX.Play();
        rb.AddForce(Vector2.up * jSpeed);
    }
}
