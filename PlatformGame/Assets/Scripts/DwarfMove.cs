using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DwarfMove : MonoBehaviour {

	private Rigidbody2D rigidbody2d;
	private int score;

	public float jumpHigh;
	public float speed;
	public float baseMovement;
	public float movementBonus;
	public Text scoreText;
    public SceneFader sceneFader;
    public Canvas pauseMenuCanvas;
    public LevelCompleted levelCompleted;

	void Awake() {
		rigidbody2d = GetComponent<Rigidbody2D>();
		score = 0;
		SetScoreText();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump")) {
			rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, 0);
			rigidbody2d.AddForce(new Vector2(0.0f, jumpHigh));
		}
		if (Input.GetButtonDown("Horizontal")) {
			rigidbody2d.AddForce(new Vector2(speed, 0.0f));
			
		}
		// else if (rigidbody2d.velocity.x > 0) {
		// 	rigidbody2d.AddForce(new Vector2(-friction, 0.0f));
		// }
		else {
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
        if (other.gameObject.CompareTag("Diamond"))
        {
            other.gameObject.SetActive(false);
            baseMovement = 0;
            rigidbody2d.AddForce(new Vector2(0.0f, 0.0f));
            LevelCompletedAction();
        }

        SetScoreText();
	
	}

	void SetScoreText() {
		scoreText.text = "Score: " + score.ToString();
	}

    void LevelCompletedAction()
    {
        pauseMenuCanvas.enabled = false;
        PlayerPrefs.SetInt("levelReached", 2);
        levelCompleted.levelCompletedMenuUI.SetActive(true);
        levelCompleted.UpdateScoreValue(score);
    }
}
