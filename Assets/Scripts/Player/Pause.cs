using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            Cursor.visible = true;
            pausePanel.SetActive(true);
            Time.timeScale = 0.0f;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Load()
    {
        StartCoroutine(LoadMenu());
    }

    IEnumerator LoadMenu()
    {
        //Cursor.lockState = CursorLockMode.;
        pausePanel.SetActive(false);
        SceneManager.LoadScene("Menu");
        yield return null;
    }

    public void Resume()
    {
        Cursor.visible = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
