using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {

    public float launchPower = 15.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Enemy")
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, launchPower);
        }
    }
}
