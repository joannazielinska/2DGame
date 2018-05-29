using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject gameOverMenuUI;
    public SceneFader sceneFader;
    public string currentSceneName;
    private string mainMenuScene = "Menu";

    public void Retry()
    {
        sceneFader.FadeTo(currentSceneName);
    }

    public void Menu()
    {
        sceneFader.FadeTo("Menu");
    }


}
