using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoSingleton<EventManager>
{
    // create state events and define 
    public delegate void StateActions();
    public event StateActions MainMenuEvent;
    public event StateActions InGameEvent;
    public event StateActions PauseEvent;
    public event StateActions GameOverEvent;
    public event StateActions EndGameEvent;
    public event StateActions ShopEvent;


    // we subscribe functions to events
    private void Awake()
    {
        #region MainMenu Event Subscribe
        MainMenuEvent += UIManager.Instance.GetMainMenuCoin;
        #endregion

        #region InGame Event Subscribe
        InGameEvent += UIManager.Instance.UpdateInGameCoin;
        #endregion

        #region Pause Event Subscribe

        #endregion

        #region GameOver Event Subscribe
        GameOverEvent += UIManager.Instance.GameOver;
        #endregion

        #region EndGame Event Subscribe
        EndGameEvent += UIManager.Instance.EndGame;
        EndGameEvent += UIManager.Instance.UpdateEndGameCoin;
        #endregion

        #region Shop Event Subscribe

        #endregion

    }

    // after check state we call events in update 
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
