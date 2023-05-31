using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCanvasScript : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text livesText;
    [SerializeField] private Text highScoreText;

    private PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        UpdateLives();
    }

    private void UpdateScore()
    {
        int score = playerScript.GetPlayerScore();
        scoreText.text = "Score\n" + score;
    }

    private void UpdateLives()
    {
        int lives = playerScript.GetPlayerLives();
        livesText.text = "Lives\n" + lives;
    }

}
