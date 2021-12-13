using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    // define UI panels in Inspector
    public GameObject MainMenuPanel, InGamePanel, PausePanel, GameOverPanel, EndGamePanel;
    public Text inGameCoin, mainMenuCoinText,endGameEarnedText,endGameTotalCoinText;

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
