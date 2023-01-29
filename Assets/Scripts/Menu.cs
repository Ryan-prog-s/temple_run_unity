using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public Button letsGoButton;
    public TMP_Dropdown dropdownLevels;

    // SettingsScreen
    public GameObject settingsScreen;
    public Slider volumeSlider;
    public TMP_Dropdown dropdownKeyboard;

    // BackMenu Screen
    public GameObject backMenuScreen;
    public Button backButton;

    //private float _volume;
    //public float Volume
    //{
    //    get => _volume;
    //    set
    //    {
    //        _volume = value;
    //        AudioListener.volume = value;
    //     }
    //}

    // Start is called before the first frame update
    void Start()
    {

        //volumeSlider.minValue = 0;
        //volumeSlider.maxValue = 100;
        //Volume = AudioListener.volume;
        //volumeSlider.value = Volume;



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

        letsGoButton.onClick.AddListener(BeginGame);

        dropdownKeyboard.onValueChanged.AddListener(delegate
        {
            DropdownKeyboardValueChanged(dropdownKeyboard);
        });

        dropdownLevels.onValueChanged.AddListener(delegate
        {
            DropdownLevelValueChanged(dropdownLevels);
        });
    }

    private void BeginGame()
    {
        int optionLevel = PlayerPrefs.GetInt("SelectedOptionLevel");
        int optionkeyboard = PlayerPrefs.GetInt("SelectedOptionKeyboard");
        SceneManager.LoadScene(1, LoadSceneMode.Single);
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

    void DropdownLevelValueChanged(TMP_Dropdown change)
    {
        Debug.Log(change.value);
        PlayerPrefs.SetInt("SelectedOptionLevel", change.value);
    }

    void DropdownKeyboardValueChanged(TMP_Dropdown change)
    {
        Debug.Log(change.value);
        PlayerPrefs.SetInt("SelectedOptionKeyboard", change.value);
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
