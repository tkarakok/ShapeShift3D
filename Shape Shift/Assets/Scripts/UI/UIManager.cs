using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    // define UI panels in Inspector
    public GameObject mainMenuPanel, inGamePanel, pausePanel, gameOverPanel, endGamePanel, settingsPanel;
    public Text inGameCoin, mainMenuCoinText, endGameEarnedText,mainMenuLevelText,inGameLevelText,endGameLevelText;

    // Define level progressbar elements
    public Slider levelProgressBar;
    public GameObject finishLine;
    private float _maxDistance;

    private void Start()
    {
        _maxDistance = finishLine.transform.position.z - CubeController.Instance.gameObject.transform.position.z;
        mainMenuLevelText.text = "LEVEL " + (LevelManager.Instance.CurrentLevel + 1).ToString();
        inGameLevelText.text = "LEVEL " + (LevelManager.Instance.CurrentLevel + 1).ToString();
    }

    private void Update()
    {
        if (StateManager.Instance._state == State.InGame)
        {
            float distance = finishLine.transform.position.z - CubeController.Instance.transform.position.z;
            levelProgressBar.value = 1 - (distance / _maxDistance);
        }
    }

    // write functions for UI Button
    #region Button Functions

    public void StartGame()
    {
        StateManager.Instance._state = State.InGame;
        mainMenuPanel.SetActive(false);
        inGamePanel.SetActive(true);
    }

    public void PauseGame()
    {
        StateManager.Instance._state = State.Pause;
        inGamePanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void ContinoueButton()
    {
        StateManager.Instance._state = State.InGame;
        pausePanel.SetActive(false);
        inGamePanel.SetActive(true);
    }

    public void RestartButton()
    {
        LevelManager.Instance.ChangeLevel("LEVEL " + LevelManager.Instance.CurrentLevel);
    }

    public void NextLevelButton()
    {
        Debug.Log(LevelManager.Instance.CurrentLevel);
        LevelManager.Instance.ChangeLevel("LEVEL " + LevelManager.Instance.CurrentLevel);
    }

    public void SettingsButton()
    {
        settingsPanel.SetActive(true);
    }

    public void BackButton() 
    {
        settingsPanel.SetActive(false);
    }

    #endregion

    // write functions for events
    #region Panel Change Functions For Events
    public void GameOver()
    {
        inGamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void EndGame()
    {
        inGamePanel.SetActive(false);
        endGamePanel.SetActive(true);
    }
    #endregion

    // Update UI elements 
    #region UI Update 
    public void GetMainMenuCoin()
    {
        mainMenuCoinText.text = GameManager.Instance.TotalCoin.ToString();
    }

    public void UpdateInGameCoin()
    {
        inGameCoin.text = GameManager.Instance.Coin.ToString();
    }

    public void UpdateEndGameCoin()
    {
        endGameEarnedText.text = GameManager.Instance.Coin.ToString();
        endGameLevelText.text = "LEVEL " +(LevelManager.Instance.CurrentLevel).ToString();
    }
    #endregion

}
