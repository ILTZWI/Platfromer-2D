using System;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public event Action<Item> Encountered;

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Encountered?.Invoke(this);
        }
    }
}
