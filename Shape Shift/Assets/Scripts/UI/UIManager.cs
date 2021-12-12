using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public GameObject MainMenuPanel, InGamePanel, PausePanel;
    public Text inGameCoin, mainMenuCoinText;

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

}
