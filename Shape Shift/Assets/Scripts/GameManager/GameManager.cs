using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    // we define user's coin value
    private int _coin = 0;
    private int _totalCoin;

    //
    private int _perfect = 0;
    

    // encapsulation for coin properties
    public int Coin { get => _coin; set => _coin = value; }
    public int TotalCoin { get => _totalCoin; set => _totalCoin = value; }
    public int Perfect { get => _perfect; set => _perfect = value; }

    private void Start()
    {
        // we get user's all coin and set the variable
        TotalCoin = PlayerPrefs.GetInt("Coin");
    }



    
}
