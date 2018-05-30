using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public Text scoreText;
    public Canvas pauseMenuCanvas;
    public PauseMenu pauseMenu;
    public LevelCompleted levelCompleted;
    public GameOver gameOver;

    private int dwarfScore;
    private int livesNum;

    private void Awake()
    {
        dwarfScore = 0;
        livesNum = 3;
    }

    public void GameOver()
    {
        pauseMenuCanvas.enabled = false;
        gameOver.gameOverMenuUI.SetActive(true);

    }

    public void incrementScore(int num)
    {
        dwarfScore += num;
    }

}
