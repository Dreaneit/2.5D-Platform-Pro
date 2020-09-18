using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private UIManager uiManager;
    private void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.CollectCoin();
                uiManager.RenderCollectedCoins(player.GetCollectedCoins());
            }
        }
        
        Destroy(this.gameObject);
    }
}
