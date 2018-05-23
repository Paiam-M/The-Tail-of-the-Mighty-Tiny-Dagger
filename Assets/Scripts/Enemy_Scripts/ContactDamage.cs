using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour {

    public GameObject contactSource;
    public int dmg = 20;
    public float hitstun = 0.25f;
    public float xkb = 15;
    public float ykb = 4;

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerStats>().health -= dmg;
            collision.GetComponent<PlayerController>().enabled = !collision.GetComponent<PlayerController>().enabled;
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            if (collision.GetComponent<Transform>().position.x > contactSource.transform.position.x)
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(xkb, ykb), ForceMode2D.Impulse);
            else
                collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-xkb, ykb), ForceMode2D.Impulse);

            yield return new WaitForSecondsRealtime(hitstun);
            collision.GetComponent<PlayerController>().enabled = !collision.GetComponent<PlayerController>().enabled;
        }
    }
}
