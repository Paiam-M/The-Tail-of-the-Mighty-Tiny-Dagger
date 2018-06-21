using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeBasic : MonoBehaviour {

    public Animator animator;
    public int throwTime;
    public int maxThrowTime;
    public GameObject system;
    public GameObject player;

    private Vector2 originalPos;

    void Update()
    {
        if (throwTime == maxThrowTime)
        {
            originalPos = transform.position;
        }
        if (throwTime > 1 && player.GetComponent<PlayerController>().isFacingRight)
        {
            system.GetComponent<Animator>().Play("PlayerMeleeRight");
            transform.position = new Vector2(originalPos.x + 1, originalPos.y);
            originalPos.x++;
            throwTime--;
        }
        else if (throwTime > 1 && player.GetComponent<PlayerController>().isFacingLeft)
        {
            system.GetComponent<Animator>().Play("PlayerMeleeLeft");
            transform.position = new Vector2(originalPos.x - 1, originalPos.y);
            originalPos.x--;
            throwTime--;
        }
        else
        {
            if(player.GetComponent<PlayerController>().isFacingRight)
                originalPos = new Vector2(player.transform.position.x + .5f, player.transform.position.y - .5f);
            else
                originalPos = new Vector2(player.transform.position.x - .5f, player.transform.position.y - .5f);
            system.GetComponent<Animator>().Play("PlayerNoMelee");
            transform.position = originalPos;
            //transform.position = originalPos;
        }
    }
}
