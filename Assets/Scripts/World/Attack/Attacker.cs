using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRadius;
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _owner;

    public bool IsDetected { get; private set; } = false;

    public event Action<IDamageable, bool> Detected;

    public void DetectEnemy()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius);

        foreach (Collider2D hit in hitEnemies)
        {
            if (hit.gameObject != _owner && hit.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(_damage);
                Detected?.Invoke(damageable, IsDetected);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f,106f,255f,0.5f);
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRadius);
    }
}