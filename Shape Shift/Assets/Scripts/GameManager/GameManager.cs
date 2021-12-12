using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private int _coin = 10;
    private int _totalCoin;

    public int Coin { get => _coin; set => _coin = value; }
    public int TotalCoin { get => _totalCoin; set => _totalCoin = value; }

    private void Start()
    {
        TotalCoin = PlayerPrefs.GetInt("coin");
        UIManager.Instance.inGameCoin.text = Coin.ToString();
        UIManager.Instance.mainMenuCoinText.text = TotalCoin.ToString();
    }
}
