﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public int toBuildIndex;
    public CanvasGroup fader;
    public GameObject helpPanel;
    public GameObject menuPanel;

    public void Load()
    {
        MenuSelectSFX.playSFX();
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        while (!Mathf.Approximately(fader.alpha, 1))
        {
            fader.alpha = Mathf.MoveTowards(fader.alpha, 1, Time.deltaTime);
            yield return null;
        }
        //SceneManager.LoadScene(toBuildIndex, LoadSceneMode.Single);
        SceneManager.LoadScene("MainGame");
    }

    public void Exit()
    {
        MenuSelectSFX.playSFX();
        //only for when running in editor
        //UnityEditor.EditorApplication.isPlaying = false;
        
        Application.Quit();
    }

    public void Help()
    {
        MenuSelectSFX.playSFX();
        menuPanel.SetActive(false);
        helpPanel.SetActive(true);
    }

    public void Back()
    {
        MenuSelectSFX.playSFX();
        helpPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
