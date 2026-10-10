using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _coins;

    public void AddCoinToWallet()
    {
        Debug.Log("Метод AddCoinToWallet вызван");
        _coins++;
        Debug.Log($"{_coins}");
    }
}
