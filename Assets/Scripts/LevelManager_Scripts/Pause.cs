using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public Canvas Pause_UI;

	void Update ()
    {
        if (Input.GetKeyDown("Esc"))
            Pause_UI.enabled = !Pause_UI.enabled;

	}
}
