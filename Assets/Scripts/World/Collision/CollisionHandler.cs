using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action<Collision2D> Encountered;

    private void OnCollisionEnter2D(Collision2D collision)
    {
            Encountered?.Invoke(collision);
    }
}
