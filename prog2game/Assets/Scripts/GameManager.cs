using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text livesText;
    [SerializeField] private Text highScoreText;
    private int highScore;
    private bool newHighScore;
    private bool gameOver;

    private PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        newHighScore = false;
        gameOver = false;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            highScore = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCanvasScore();
        UpdateCanvasLives();
        UpdateCanvasHighScore();
        UpdateGameOver();
        if(newHighScore)
        {
            SaveHighScore();
        }
    }

    private void UpdateCanvasScore()
    {
        int score = playerScript.GetPlayerScore();
        scoreText.text = "Score\n" + score;
    }

    private void UpdateCanvasLives()
    {
        int lives = playerScript.GetPlayerLives();
        if(lives < 0)
        {
            lives = 0;
        }
        livesText.text = "Lives\n" + lives;
    }

    private void UpdateCanvasHighScore()
    {
        if (playerScript.GetPlayerScore() > highScore)
        {
            highScoreText.text = "High Score\n" + playerScript.GetPlayerScore();
            newHighScore = true;
        }
        else
        {
            highScoreText.text = "High Score\n" + highScore;
        }
    }

    private void UpdateGameOver()
    {
        if(playerScript.GetPlayerLives() <= 0)
        {
            gameOver = true;
        }
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", playerScript.GetPlayerScore());
        PlayerPrefs.Save();
    }

    public bool isGameOver()
    {
        return gameOver;
    }

}
