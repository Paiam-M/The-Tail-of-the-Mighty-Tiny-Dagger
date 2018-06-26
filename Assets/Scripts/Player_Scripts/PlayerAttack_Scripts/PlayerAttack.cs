using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public PlayerBasicAttack currentAttackType;

    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            Attack();
        }
    }

    void Attack()
    {
        if(currentAttackType)
            currentAttackType.attackTime = currentAttackType.maxAttackTime;
    }
}
