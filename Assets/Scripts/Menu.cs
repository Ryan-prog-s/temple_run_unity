using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    // MainScreen 
    public GameObject mainScreen;

    public Button playButton;
    public Button optionButton;
    public Button quitButton;

    // LevelScreen
    public GameObject levelScreen;

    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;
    public Button hardcoreButton;
    public Button ininityButton;

    // SettingsScreen
    public GameObject settingsScreen;
    public Slider volumeSlider;

    // BackMenu Screen
    public GameObject backMenuScreen;
    public Button backButton;

    private float _volume;
    public float Volume
    {
        get => _volume;
        set
        {
            _volume = value;
            AudioListener.volume = value;
         }
    }

    // Start is called before the first frame update
    void Start()
    {

        volumeSlider.minValue = 0;
        volumeSlider.maxValue = 100;
        Volume = AudioListener.volume;
        volumeSlider.value = Volume;

        // Active or deactivate the screens
        mainScreen.SetActive(true);
        settingsScreen.SetActive(false);
        levelScreen.SetActive(false);
        backMenuScreen.SetActive(false);

        // On click buttons
        playButton.onClick.AddListener(DisplayPlay);
        optionButton.onClick.AddListener(DisplayOptions);
        quitButton.onClick.AddListener(Exit);
        backButton.onClick.AddListener(BackToMenu);
    }
    private void DisplayPlay()
    {
        mainScreen.SetActive(false);
        levelScreen.SetActive(true);
        backMenuScreen.SetActive(true);
    }

    private void DisplayOptions()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
        backMenuScreen.SetActive(true);
    }

    private void BackToMenu()
    {
        levelScreen.SetActive(false);
        mainScreen.SetActive(true);
        backMenuScreen.SetActive(false);
        settingsScreen.SetActive(false);
    }
    private void Exit()
    {
        Application.Quit();
    }
   

    // Update is called once per frame
    void Update()
    {

    }
}
