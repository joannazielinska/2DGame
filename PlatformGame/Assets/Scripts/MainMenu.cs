﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string levelToLoad;
    //public SceneFader sceneFader;

    public void PlayGame()
    {
        //sceneFader.FadeTo(levelToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
