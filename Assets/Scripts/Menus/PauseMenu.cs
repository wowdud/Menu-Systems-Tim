using CanvasUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pauseScreen;
    public GameObject optionsScreen;

    public void Pause()
    {
        if (!optionsScreen.activeSelf)
        {
            isPaused = true;
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            pauseScreen.SetActive(true);
        }
    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseScreen.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyBindManager.keys["Pause"]))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Pause();
                isPaused = true;
            }
            else
            {
                if (!optionsScreen.activeInHierarchy)
                {
                    Unpause();
                    isPaused = false;
                }
            }
        }
    }
}
