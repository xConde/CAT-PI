using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused;

    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape") && isPaused == false)
        {
            Cursor.visible = true;
            pausePanel.SetActive(true);
            Time.timeScale = 0.0f;
            Cursor.lockState = CursorLockMode.None;
            isPaused = true;
        }
    }

    public void Load()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainGame");
    }

    public void Resume()
    {
        isPaused = false;
        Cursor.visible = false;
        pausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
    }

    public void Exit()
    {

    }
}
