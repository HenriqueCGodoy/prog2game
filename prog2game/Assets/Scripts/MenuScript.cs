using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject clearHighScorePanel;

    // Start is called before the first frame update
    void Start()
    {
        clearHighScorePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ClearHighScoreWindow()
    {
        clearHighScorePanel.SetActive(true);
    }

    public void ClearHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.DeleteKey("HighScore");
        }
        clearHighScorePanel.SetActive(false);
    }

    public void DontClearHighScore()
    {
        clearHighScorePanel.SetActive(false);
    }
}
