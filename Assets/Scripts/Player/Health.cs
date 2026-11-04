using UnityEngine;

public class Health : MonoBehaviour
{
    public int HealthLevel { get; private set; } = 100;

    public void TakeDamage(int damage)
    {
        HealthLevel -= damage;
        Debug.Log("Теряем здоровье" + HealthLevel);
    }

    public void Healthing(int healingValue)
    {
        HealthLevel += healingValue;
        Debug.Log("Лечимся" + HealthLevel);
    }
}
