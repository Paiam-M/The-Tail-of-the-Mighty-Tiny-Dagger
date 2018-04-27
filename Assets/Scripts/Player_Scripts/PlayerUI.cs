using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
    public Text playerStats;
    public PlayerStats stats;

	void Update () {
        playerStats.text = "Health: " + stats.health + "\n" + "Armor: " + stats.armor;
	}
}
