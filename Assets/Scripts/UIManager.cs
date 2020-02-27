using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text CoinText;
    [SerializeField] private Text LifeText;

    public void UpdateCoinDisplay(int coins)
    {
        CoinText.text = "Coins: " + coins.ToString();
    }
    public void UpdateLifeDisplay(int Life)
    {
        LifeText.text = Life.ToString() + " :Life";
    }
}
