
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    // enable script to be accessible from other scripts
    public static GameController gameController;

    // ui components
    public TMP_Text scoreValueText;

    public TMP_Text timerValueText;

    public GameObject titleScreen;

    public GameObject gameOverScreen;

    // player score
    private int score;

    // game timer
    private float timer;

    // if the game is in play
    [HideInInspector] public bool gameIsActive;

    // number of points for a cabbage
    [HideInInspector] public int cabbagePoints;



    private void Awake()
    {
        gameController = this;
    }


    void Start()
    {
        // show the title screen
        titleScreen.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        if (gameIsActive)
        {
            UpdateTimer();
        }
    }


    public void StartGame()
    {        
        score = 0;

        cabbagePoints = 1;

        timer = 60f;

        // set the score
        CollectCabbages(score);

        // hide the title screen
        titleScreen.SetActive(false);

        // game is in play
        gameIsActive = true;
    }


    // stop game, bring up game over text and restart button
    private void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);

        gameIsActive = false;
    }


    public void CollectCabbages(int cabbagePoints)
    {
        score += cabbagePoints;

        UIController.uiController.scoreValueText.text = score.ToString();
    }


    private void UpdateTimer()
    {
        timer -= Time.deltaTime;

        SetTimerFormat();

        if (timer < 0)
        {
            timer = 0f;

            GameOver();
        }
    }


    private void SetTimerFormat()
    {
        // convert time to minutes and seconds
        int minutes = ((int)timer / 60);

        int seconds = ((int)timer % 60);

        // format and display the remaining time
        UIController.uiController.timerValueText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    // restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


} // end of class
