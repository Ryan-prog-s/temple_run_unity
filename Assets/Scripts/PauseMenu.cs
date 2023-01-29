using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    GameObject[] pauseObjects;

    public Button playButton;
    public Button quitButton;
    public Button backToMainMenuButton;

    public Button pauseButton;

    public static bool gameIsPaused;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        HidePaused();

        // On click buttons
        playButton.onClick.AddListener(DisplayPlay);
        quitButton.onClick.AddListener(Exit);
        backToMainMenuButton.onClick.AddListener(BackToMainMenu);
        pauseButton.onClick.AddListener(PauseScreen);
    }

    private void PauseScreen()
    {
        gameIsPaused = !gameIsPaused;
        PauseGame();
    }

    private void DisplayPlay()
    {
        gameIsPaused = !gameIsPaused;
        PauseGame();
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        HidePaused();
    }

    // Update is called once per frame

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }

    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            ShowPaused();
        }
        else
        {
            Time.timeScale = 1;
            HidePaused();

        }
    }

    //shows objects with ShowOnPause tag
    public void ShowPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void HidePaused()
    {
        gameIsPaused = false;
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
}
