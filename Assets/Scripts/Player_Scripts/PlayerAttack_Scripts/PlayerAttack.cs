using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public PlayerBasicAttack currentAttackType;
    public GameObject pauseUI;
    public GameObject inventoryUI;

    void Update()
    {
        if (!pauseUI.activeSelf && !inventoryUI.activeSelf && Input.GetButtonDown("Attack"))
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
