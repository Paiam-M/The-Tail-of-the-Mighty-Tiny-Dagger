using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeBasic : MonoBehaviour {

    public PlayerController player;

    [Header("Melee Attack Attributes")]
    public int damage = 0;  //Amount of damage that will be dealt to enemies
    public float range = 3.0f;  //range of raycast
    public float cdtime = 1.0f; //Cooldown time before you can attack again
    public LayerMask mask = -1; //Used for hit detection of raycast attack

    private bool coolingdown = false;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (coolingdown == false)
            {
                print("Firing.\n");
                StartCoroutine("Cooldown");
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * player.GetComponent<PlayerController>().front, range, mask);
                if (hit.collider.tag == ("Enemy"))
                {
                    EnemyHealthDmg enemy = hit.collider.gameObject.GetComponent<EnemyHealthDmg>() ;
                    enemy.takeDamage(damage);
                }
                else
                {
                    Debug.Log("Hitting Nothing.");
                }
            }
            else
            {
                Debug.Log("Attack is in cooldown.");
            }
        }
    }

    private IEnumerator Cooldown()
    {
        coolingdown = true;
        yield return new WaitForSeconds(cdtime);
        coolingdown = false;
    }
}
