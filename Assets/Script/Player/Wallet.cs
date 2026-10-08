using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public  float Coins {  get; private set; }

    public void AddCoinToWallet()
    {
        Coins++;
    }
}
