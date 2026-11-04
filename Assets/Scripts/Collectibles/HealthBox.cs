using System;
using UnityEngine;

public class HealthBox : MonoBehaviour
{
    public int HealingValue { get; private set; } = 15;

    public event Action<HealthBox> Encountered;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Encountered?.Invoke(this);
        }
    }
}
