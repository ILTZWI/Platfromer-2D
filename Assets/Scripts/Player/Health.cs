using UnityEngine;

public class Health : MonoBehaviour
{
    public int HealthLevel { get; private set; } = 100;

    public void TakeDamage(int damage)
    {
        HealthLevel -= damage;
    }

    public void Healthing(int healingValue)
    {
        HealthLevel += healingValue;
    }
}
