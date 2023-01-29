using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{

    GameObject[] gameoverObjects;

    public Button backToMenuButton;
    public Button restartGameButton;
    public Button quitButton;
    public static bool isGameOver;

    public TMP_Text message;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameoverObjects = GameObject.FindGameObjectsWithTag("ShowOnGameOver");
        HideGameOver();

        // On click buttons
        restartGameButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(Exit);
        backToMenuButton.onClick.AddListener(BackToMainMenu);

        message = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameOverGame();
        if (Ways.isFinish == true)
        {
            ShowGameOver("Well done !");
        }
    }

    private void GameOverGame()
    {
        if (isGameOver)
        {
            Time.timeScale = 0f;
            ShowGameOver("Game Over");
        }
        else
        {
            Time.timeScale = 1;
            HideGameOver();
        }
    }

    private void RestartGame()
    {
        HideGameOver();
        SceneManager.LoadScene(1);
    }

    private void Exit()
    {
        HideGameOver();
        Application.Quit();
    }

    private void BackToMainMenu()
    {
        HideGameOver();
        SceneManager.LoadScene(0);
    }

    public void ShowGameOver(string currentMessage)
    {
        message = GetComponent<TMP_Text>();
        foreach (GameObject g in gameoverObjects)
        {
            g.SetActive(true);
        }
        message.text = currentMessage;
    }

    public void HideGameOver()
    {
        isGameOver = false;
        foreach (GameObject g in gameoverObjects)
        {
            g.SetActive(false);
        }
    }
}
