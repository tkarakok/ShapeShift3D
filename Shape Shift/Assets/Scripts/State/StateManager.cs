using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoSingleton<StateManager>
{
    public State _state;

    private void Start()
    {
        _state = State.MainMenu;
    }
}

public enum State
{
    MainMenu,
    InGame,
    Pause,
    Shop,
    EndGame,
    GameOver
}

