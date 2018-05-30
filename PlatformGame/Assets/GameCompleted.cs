using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompleted : MonoBehaviour {

    public GameObject gameCompletedMenuUI;
    public SceneFader sceneFader;
    public string currentSceneName;
    public string firstLevelScenceName;
    private string mainMenuScene = "Menu";


    public void PlayAgain()
    {
        PlayerPrefs.DeleteAll();
        sceneFader.FadeTo(firstLevelScenceName);
    }

    public void Menu()
    {
        sceneFader.FadeTo("Menu");
    }
}
