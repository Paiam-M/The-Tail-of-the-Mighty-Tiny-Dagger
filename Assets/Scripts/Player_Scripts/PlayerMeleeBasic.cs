using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeBasic : MonoBehaviour {

    public Animator animator;
    public int swingTime;
    public int maxSwingTime;
    public GameObject system;
    public GameObject player;

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
        if (swingTime > 1)
        {
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
            swingTime--;
        }
        else
        {
            system.GetComponent<Animator>().Play("PlayerNoMelee");
            originalPos = player.transform.position;
            angle = 0f;
        }
        /*
        if (swingTime == maxSwingTime)
        {
            originalPos = transform.position;
        }

        if (swingTime > 1)
        {
            system.GetComponent<Animator>().Play("PlayerSwordSwing");
            transform.position = new Vector2(originalPos.x * originalPos.x, originalPos.y * originalPos.y);
        }
        */
    }
}
