﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public int toBuildIndex;
    public CanvasGroup fader;

    public void Load()
    {
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
        //only for when running in editor
        UnityEditor.EditorApplication.isPlaying = false;
        
        Application.Quit();
    }
}
