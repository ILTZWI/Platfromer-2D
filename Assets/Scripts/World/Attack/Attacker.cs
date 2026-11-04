using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRadius;
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _owner;


    public void DetectEnemy()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius);

        foreach (Collider2D hit in hitEnemies)
        {
            if (hit.gameObject != _owner && hit.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(_damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.darkRed;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRadius);
    }
}