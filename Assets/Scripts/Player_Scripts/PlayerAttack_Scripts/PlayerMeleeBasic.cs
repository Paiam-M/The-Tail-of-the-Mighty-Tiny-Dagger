using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeBasic : PlayerBasicAttack {

    private float RotateSpeed = 5f;
    public float radius = 1f;

    private Vector2 originalPos;
    private float angle;
    private bool isActiveLeft;
    private bool isActiveRight;

    private void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        PlayerController controllerComponent = player.GetComponent<PlayerController>();
        if (attackTime > 1)
        {
            GetComponent<BoxCollider2D>().size = new Vector2(1f,1f);
            system.GetComponent<Animator>().Play("PlayerSwordSwing");
            angle += RotateSpeed * 5f;

            if (controllerComponent.isFacingRight)
            {
                var offest = new Vector2(Mathf.Cos(angle) + 0.7f * radius, Mathf.Sin(angle) + 0.3f * radius);
                transform.position = originalPos + offest;
            }
            else if(controllerComponent.isFacingLeft)
            {
                var offest = new Vector2(-Mathf.Cos(angle) - 0.7f * radius, Mathf.Sin(angle) + 0.3f * radius);
                transform.position = originalPos + offest;
            }
            attackTime--;
        }
        else
        {
            GetComponent<BoxCollider2D>().size = new Vector2(0.0001f, 0.0001f); ;
            system.GetComponent<Animator>().Play("PlayerNoMelee");
            originalPos = player.transform.position;
            angle = 0f;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealthDmg>().takeDamage(5f);
        }
    }
}
