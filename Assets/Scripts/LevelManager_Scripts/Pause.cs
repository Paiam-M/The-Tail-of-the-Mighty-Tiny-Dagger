using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {
    public GameObject PauseUI;
    public bool isPaused;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Resume();
	}

    public void Resume()
    {
        PauseUI.SetActive(!isPaused);
        isPaused = !isPaused;
        Time.timeScale = 1;
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
