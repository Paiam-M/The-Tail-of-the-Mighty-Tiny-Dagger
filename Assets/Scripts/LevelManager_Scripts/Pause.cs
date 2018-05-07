using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {
    public GameObject PauseUI;
    public bool isPaused;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            PauseUI.SetActive(true);
            isPaused = !isPaused;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            PauseUI.SetActive(false);
            isPaused = !isPaused;
            Time.timeScale = 1;
        }
	}
}
