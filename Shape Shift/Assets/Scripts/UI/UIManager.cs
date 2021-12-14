using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    // define UI panels in Inspector
    public GameObject MainMenuPanel, InGamePanel, PausePanel, GameOverPanel, EndGamePanel;
    public Text inGameCoin, mainMenuCoinText, endGameEarnedText, endGameTotalCoinText, currentLevelText, nextLevelText;

    // Define level progressbar elements
    public Slider levelProgressBar;
    public GameObject finishLine;
    private float _maxDistance;

    private void Start()
    {
        _maxDistance = finishLine.transform.position.z - CubeController.Instance.gameObject.transform.position.z;
        currentLevelText.text = (LevelManager.Instance.CurrentLevel+1).ToString();
        nextLevelText.text = (LevelManager.Instance.CurrentLevel+2).ToString();
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
        MainMenuPanel.SetActive(false);
        InGamePanel.SetActive(true);
    }

    public void PauseGame()
    {
        StateManager.Instance._state = State.Pause;
        InGamePanel.SetActive(false);
        PausePanel.SetActive(true);
    }

    public void ContinoueButton()
    {
        StateManager.Instance._state = State.InGame;
        PausePanel.SetActive(false);
        InGamePanel.SetActive(true);
    }

    public void RestartButton()
    {
        LevelManager.Instance.ChangeLevel("Level " + LevelManager.Instance.CurrentLevel);
    }

    public void NextLevelButton()
    {
        Debug.Log(LevelManager.Instance.CurrentLevel);
        LevelManager.Instance.ChangeLevel("Level " + LevelManager.Instance.CurrentLevel);
    }
    #endregion

    // write functions for events
    #region Panel Change Functions For Events
    public void GameOver()
    {
        InGamePanel.SetActive(false);
        GameOverPanel.SetActive(true);
    }

    public void EndGame()
    {
        InGamePanel.SetActive(false);
        EndGamePanel.SetActive(true);
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
        endGameTotalCoinText.text = (GameManager.Instance.TotalCoin + GameManager.Instance.Coin).ToString();
    }
    #endregion



}
