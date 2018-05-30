using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DwarfMove : MonoBehaviour {

	private Rigidbody2D rigidbody2d;
	private int score;
	private int livesNum;

	public float jumpHigh;
	public float speed;
	public float baseMovement;
	public float movementBonus;
	public Text scoreText;
	public Text livesText;
    public SceneFader sceneFader;
    public Canvas pauseMenuCanvas;
    public LevelCompleted levelCompleted;
    public GameOver gameOver;
    public int currentLevelNum;
    public int lifeNumber;

	void Awake() {
		rigidbody2d = GetComponent<Rigidbody2D>();
		score = 0;
		livesNum = lifeNumber;
		SetScoreText();
		SetLivesText();
	}
	
	void Update () {

        if(livesNum == 0)
        {
            FreezePlayer();
            GameOver();
        }
		if (Input.GetButtonDown("Jump")) {
			rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, 0);
			rigidbody2d.AddForce(new Vector2(0.0f, jumpHigh));
		}
		if (Input.GetButtonDown("Horizontal")) {
			rigidbody2d.AddForce(new Vector2(speed, 0.0f));
			
		}
		else
        {
			rigidbody2d.velocity = new Vector2(baseMovement, rigidbody2d.velocity.y);
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Coin")){
			other.gameObject.SetActive(false);
			score +=10;
		}
		
		if (other.gameObject.CompareTag("Food")){
			other.gameObject.SetActive(false);
			score +=5;
		}
		if (other.gameObject.CompareTag("RedElixir") && baseMovement- movementBonus>0){
			other.gameObject.SetActive(false);
			baseMovement -= movementBonus;
		}
		if (other.gameObject.CompareTag("BlueElixir")){
			other.gameObject.SetActive(false);
			baseMovement += movementBonus;
		}
		if (other.gameObject.CompareTag("Enemy"))
        {
            if (livesNum == 0)
            {
                this.gameObject.SetActive(false);
            } else
            {
                livesNum -= 1;
            }
        }
        if (other.gameObject.CompareTag("Obstacle")) {

            if (livesNum == 0)
            {
                FreezePlayer();
            }
            else
            {
                livesNum -= 1;
            }
		}
		if (other.gameObject.CompareTag("Live") ){
			if (livesNum < 4) livesNum +=1;
			other.gameObject.SetActive(false);
		}
        if (other.gameObject.CompareTag("Diamond"))
        {
            other.gameObject.SetActive(false);
            FreezePlayer();
            LevelCompletedAction();
        }
        if (other.gameObject.CompareTag("Water") && baseMovement - movementBonus > 0)
        {
            baseMovement -= movementBonus;
        }
        if (other.gameObject.CompareTag("Water") )
        {
            baseMovement += movementBonus;
        }

        SetScoreText();
		SetLivesText();
	
	}

	void SetScoreText() {
		scoreText.text = "Score: " + score.ToString();
	}

	void SetLivesText() {
		livesText.text = "Lives: " + livesNum.ToString();
	}

    void FreezePlayer()
    {
        baseMovement = 0;
        rigidbody2d.velocity = new Vector2(0.0f, 0.0f);
        rigidbody2d.AddForce(new Vector2(0.0f, 0.0f));
    }

    void LevelCompletedAction()
    {
        pauseMenuCanvas.enabled = false;
        PlayerPrefs.SetInt("levelReached", currentLevelNum + 1);
        levelCompleted.levelCompletedMenuUI.SetActive(true);
        levelCompleted.UpdateScoreValue(score);
    }

    void GameOver()
    {
        pauseMenuCanvas.enabled = false;
        gameOver.gameOverMenuUI.SetActive(true);
        
    }
}
