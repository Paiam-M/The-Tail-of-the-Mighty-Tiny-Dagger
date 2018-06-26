using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {
    public GameObject PauseUI;
    public GameObject InventoryUI;

    void Update ()
    {
        if (PauseUI.activeSelf || InventoryUI.activeSelf)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

        if (!InventoryUI.activeSelf && Input.GetButtonDown("Pause"))
            ResumePause();
        if (!PauseUI.activeSelf && Input.GetButtonDown("Inventory"))
            ResumeInventory();
	}

    public void ResumePause()
    {
        PauseUI.SetActive(!PauseUI.activeSelf);
    }

    public void ResumeInventory()
    {
        InventoryUI.SetActive(!InventoryUI.activeSelf);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
