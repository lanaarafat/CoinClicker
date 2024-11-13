using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class Upgrade
{
    public abstract string Name { get; }
    public abstract int Cost { get; }
    public abstract void ApplyUpgrade();
}


public class CoinMultiplierUpgrade : Upgrade
{
    public override string Name => "Double Coins";
    public override int Cost => 20;

    public override void ApplyUpgrade()
    {
        GameManager.Instance.IncreaseCoinPerClick(1); // Double the coin per click amount
    }
}

public static class UpgradeFactory
{
    public static Upgrade CreateUpgrade(string upgradeType)
    {
        switch (upgradeType)
        {
            case "Double Coins":
                return new CoinMultiplierUpgrade();
            // Add more upgrades here if desired
            default:
                return null;
        }
    }
}

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private Button upgradeButton;

    private void Start()
    {
        upgradeButton.onClick.AddListener(OnUpgradeClick);
    }

    private void OnUpgradeClick()
    {
        Upgrade upgrade = UpgradeFactory.CreateUpgrade("Double Coins");
        if (GameManager.Instance.CoinCount >= upgrade.Cost)
        {
            GameManager.Instance.AddCoins(-upgrade.Cost); // Deduct cost
            upgrade.ApplyUpgrade(); // Apply the upgrade effect
        }
        else
        {
            Debug.Log("Not enough coins for upgrade!");
        }
    }
}

