using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text coinsText, livesText;

    public void RenderCollectedCoins(int coinsCollected)
    {
        coinsText.text = $"Coins: {coinsCollected}";
    }

    public void RenderLives(int lives)
    {
        livesText.text = $"Lives: {lives}";
    }
}
