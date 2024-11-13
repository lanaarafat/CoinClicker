using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerButton : MonoBehaviour
{
    [SerializeField] private Button clickButton;

    private void Start()
    {
        clickButton.onClick.AddListener(OnCoinClick);
    }

    private void OnCoinClick()
    {
        GameManager.Instance.AddCoins(GameManager.Instance.CoinPerClick);
    }
}
