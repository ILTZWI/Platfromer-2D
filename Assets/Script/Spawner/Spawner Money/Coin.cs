using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> CoinEncountered;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Wallet wallet))
        {
            wallet.AddCoinToWallet();

            CoinEncountered?.Invoke(this);
            Debug.Log("Бам");
        }
    }
}
