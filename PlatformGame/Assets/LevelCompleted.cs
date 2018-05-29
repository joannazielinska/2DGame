using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleted : MonoBehaviour {

    public GameObject levelCompletedMenuUI;
    public SceneFader sceneFader;
    public Text scoreValue;
    public string currentSceneName;
    public string nextLevelScenceName;
    private string mainMenuScene = "Menu";

    public void UpdateScoreValue(int score)
    {
        scoreValue.text = score.ToString();
    }

    public void Retry()
    {
        sceneFader.FadeTo(currentSceneName);
    }

    public void NextLevel()
    {
        sceneFader.FadeTo(nextLevelScenceName);
    }

    public void Menu()
    {
        sceneFader.FadeTo("Menu");
    }
}
