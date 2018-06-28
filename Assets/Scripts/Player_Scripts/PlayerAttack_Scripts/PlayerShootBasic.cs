using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootBasic : PlayerBasicAttack {

    private Vector2 originalPos;

    void Update()
    {
        if (attackTime == maxAttackTime)
        {
            originalPos = transform.position;
        }
        if (attackTime > 1 && player.GetComponent<PlayerController>().isFacingRight)
        {
            GetComponent<BoxCollider2D>().size = new Vector2(1f, 1f);
            system.GetComponent<Animator>().Play("PlayerMeleeRight");
            transform.position = new Vector2(originalPos.x + 1, originalPos.y);
            originalPos.x++;
            attackTime--;
        }
        else if (attackTime > 1 && player.GetComponent<PlayerController>().isFacingLeft)
        {
            GetComponent<BoxCollider2D>().size = new Vector2(1f, 1f);
            system.GetComponent<Animator>().Play("PlayerMeleeLeft");
            transform.position = new Vector2(originalPos.x - 1, originalPos.y);
            originalPos.x--;
            attackTime--;
        }
        else
        {
            GetComponent<BoxCollider2D>().size = new Vector2(0.0001f, 0.0001f);
            if (player.GetComponent<PlayerController>().isFacingRight)
                originalPos = new Vector2(player.transform.position.x + .5f, player.transform.position.y - .5f);
            else
                originalPos = new Vector2(player.transform.position.x - .5f, player.transform.position.y - .5f);
            system.GetComponent<Animator>().Play("PlayerNoMelee");
            transform.position = originalPos;
            //transform.position = originalPos;
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
