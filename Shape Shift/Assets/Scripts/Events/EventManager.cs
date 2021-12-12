using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoSingleton<EventManager>
{
    public delegate void StateActions();
    public event StateActions InGame;

}
