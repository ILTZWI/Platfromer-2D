using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float HealthLevel { get; private set; } = 100;
    public float HealthLevelMax { get; private set; } = 100;
    public float HealthLevelMin { get; private set; } = 0;

    public event Action HealthChanged;

    public void TakeDamage(int damage)
    {
        HealthLevel -= damage;
        HealthChanged?.Invoke();
    }

    public void Healthing(int healingValue)
    {
        HealthLevel += healingValue;
        HealthChanged?.Invoke();
    }
}
