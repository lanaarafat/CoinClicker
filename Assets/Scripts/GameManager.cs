using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int CoinCount { get; private set; }
    public int CoinPerClick { get; private set; } = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoins(int amount)
    {
        CoinCount += amount;
        UIManager.Instance.UpdateCoinCount(CoinCount);
    }

    public void IncreaseCoinPerClick(int increment)
    {
        CoinPerClick += increment;
    }
}

