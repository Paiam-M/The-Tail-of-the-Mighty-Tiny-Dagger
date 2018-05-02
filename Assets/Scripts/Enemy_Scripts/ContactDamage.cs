using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour {

    public int dmg = 20;
    public float xkb = 10;
    public float ykb = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerStats>().health -= dmg;
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(xkb, ykb), ForceMode2D.Impulse);
        }
    }
}
