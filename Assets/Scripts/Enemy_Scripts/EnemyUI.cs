using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour {

    public Text healthBar;
    public NoobEnemy stats;

	void Update ()
    {
        healthBar.text = "" + stats.hitPoints;
	}
}
