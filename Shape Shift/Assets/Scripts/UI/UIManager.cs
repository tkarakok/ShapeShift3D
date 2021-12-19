using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    // define UI panels in Inspector
    public GameObject mainMenuPanel, inGamePanel, pausePanel, gameOverPanel, endGamePanel, settingsPanel, shopPanel,perfectText;
    public Text inGameCoin, mainMenuCoinText, mainMenuLevelText,inGameLevelText, endGameTotalText, endGameLevelText, endGameEarnedText, shopPanelCoinText;
    public Button buyButton;

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
        LevelManager.Instance.ChangeLevel("LEVEL " + LevelManager.Instance.CurrentLevel);
    }

    public void SettingsButton()
    {
        mainMenuPanel.GetComponent<Animator>().SetBool("Clicked", true);
        settingsPanel.SetActive(true);
    }

    public void BackButton() 
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.GetComponent<Animator>().SetBool("Clicked", false);
    }

    public void OpenShop()
    {
        StateManager.Instance._state = State.Shop;
        if (GameManager.Instance.TotalCoin >= 500)
        {
            buyButton.interactable = true;
        }
        shopPanelCoinText.text = GameManager.Instance.TotalCoin.ToString();
        shopPanel.SetActive(true);
    }

    public void CloseShop()
    {
        shopPanel.GetComponent<Animator>().SetBool("ShopMenu", false);
        StateManager.Instance._state = State.MainMenu;
        shopPanel.SetActive(false);
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
        endGameTotalText.text = PlayerPrefs.GetInt("Coin").ToString();
        endGameLevelText.text = "LEVEL " +(LevelManager.Instance.CurrentLevel).ToString();
    }
    #endregion

    #region Text Animations Controller
    public void PerfectTextAnimation()
    {
        inGamePanel.GetComponent<Animator>().SetBool("Perfect", true);
        perfectText.SetActive(true);
        StartCoroutine(ClosePerfectText());
    }
    IEnumerator ClosePerfectText()
    {
        yield return new WaitForSeconds(.32f);
        inGamePanel.GetComponent<Animator>().SetBool("Perfect", false);
        perfectText.SetActive(false);

    }
    #endregion

}
