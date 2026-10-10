using System;
using Unity.VisualScripting;
using UnityEngine;

public class CoinDetector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    public event Action<Coin> DetectCoin;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Coin coin))
        {
            DetectCoin?.Invoke(coin);
            _wallet.AddCoinToWallet();
        }
    }
}
