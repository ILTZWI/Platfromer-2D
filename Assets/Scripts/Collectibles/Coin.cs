using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> OnEncountered;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            OnEncountered?.Invoke(this);
        }
    }
}
