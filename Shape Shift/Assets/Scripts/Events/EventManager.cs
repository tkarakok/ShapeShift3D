using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoSingleton<EventManager>
{
    public delegate void StateActions();
    public event StateActions MainMenuEvent;
    public event StateActions InGameEvent;
    public event StateActions PauseEvent;
    public event StateActions GameOverEvent;
    public event StateActions EndGameEvent;
    public event StateActions ShopEvent;


    private void Awake()
    {
        MainMenuEvent += GameManager.Instance.GetCoin;
    }

    private void Update()
    {
        if (StateManager.Instance._state == State.MainMenu)
        {
            MainMenuEvent();
        }
        else if (StateManager.Instance._state == State.InGame)
        {
            InGameEvent();
        }
        else if (StateManager.Instance._state == State.Pause)
        {
            PauseEvent();
        }
        else if (StateManager.Instance._state == State.GameOver)
        {
            GameOverEvent();
        }
        else if (StateManager.Instance._state == State.EndGame)
        {
            EndGameEvent();
        }
        else if (StateManager.Instance._state == State.Shop)
        {
            ShopEvent();
        }
    }
}
