using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text coinsText;

    public void RenderCollectedCoins(int coinsCollected)
    {
        coinsText.text = $"Coins: {coinsCollected}";
    }
}
