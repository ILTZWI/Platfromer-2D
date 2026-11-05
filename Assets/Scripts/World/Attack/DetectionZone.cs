using System;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    [SerializeField] private Transform _detectPosition;
    [SerializeField] private float _detectRadius;

    public bool IsDetected {  get; private set; } = false;

    public event Action<Player,bool> Detected;

    private void Update()
    {
        DetectEnemy();
    }

    private void DetectEnemy()
    {
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(_detectPosition.position, _detectRadius);

        foreach (Collider2D hit in hitEnemy)
        {
            if (hit.TryGetComponent<Player>(out var player))
            {
                IsDetected = true;
                Detected?.Invoke(player,IsDetected);
            }
            else 
            {
                IsDetected = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_detectPosition.position, _detectRadius);
    }
}
