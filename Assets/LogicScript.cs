using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore; 
    public int highScore;
    public TMP_Text highScoreText;
    public TMP_Text Score;
    public string scoreDisplayText = "Score: ";

    
    public GameObject gameOverScreen;
    public BirdScript bird;
    public AudioSource audSource;
    public AudioSource bgMusicSource;
    public AudioSource flapAudSource;
    public AudioClip audClip;
    public AudioClip gameOverSFX;
    public AudioClip bgMusic;
    public AudioClip wingFlap;

    public bool isGameOverPlayed = false;
    

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
       

        if (PlayerPrefs.GetInt("IsMusicOn") == 1)
        {
            bgMusicSource.clip = bgMusic;
            bgMusicSource.Play();

        }


        if (PlayerPrefs.GetInt("HighScore") > 0)
        {
            highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();
        }
    }
    [ContextMenu("Increase Score")]
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGameOverPlayed == true)
        {
            RestartGame();
        }
    }
    public void addScore(int scoreToAdd)
    {
        if (bird.birdIsAlive == true)
        {
            playerScore += scoreToAdd;
            Score.text = scoreDisplayText + playerScore.ToString();
            if (PlayerPrefs.GetInt("IsSFXOn") == 1)
            {
                audSource.clip = audClip;
                audSource.Play();
            }
            //GetComponent<AudioSource>().PlayOneShot(audClip);
        }

    }

    public void RestartGame()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadHomeScreen()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void gameOver()
    {
        if (isGameOverPlayed == false)
        {
            gameOverScreen.SetActive(true);
            if (PlayerPrefs.GetInt("IsSFXOn") == 1)
            {

                audSource.clip = gameOverSFX;
                audSource.Play();
                isGameOverPlayed = true;
                bgMusicSource.Stop();
            }

            highScore = PlayerPrefs.GetInt("HighScore");
            if (playerScore > highScore)
            {
                PlayerPrefs.SetInt("HighScore", playerScore);
                highScoreText.text = "HighScore: " + playerScore.ToString();
            }
        }
        
    }
}
