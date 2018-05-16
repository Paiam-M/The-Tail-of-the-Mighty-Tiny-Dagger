using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoobEnemy : NPC {
    
    public float deathTimer = 2.5f;
    public Sprite deathState;

    private void Update()
    {
        if (hitPoints <= 0)
        {
            print("I died!");
            StartCoroutine(Death());
        }
    }

    private void Start()
    {
        hitPoints = 10;
        armor = 0;
        isEnemy = true;
    }


    IEnumerator Death()
    {
        DestroyObject(this.gameObject);
        yield return null;
    }
}
