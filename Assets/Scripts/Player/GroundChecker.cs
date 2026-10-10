using System;
using Unity.VisualScripting;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _startRay;
    [SerializeField] private LayerMask _groundLayer;

    public event Action<bool> IsGrounded;

    private bool _isGrounded;

    private void Update()
    {
        CheckGround();
    }

    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(_startRay.position, Vector2.down, 0.07f, _groundLayer);


        Debug.DrawRay(
        _startRay.position,
        Vector2.down * 0.07f,
        Color.red
    );

        IsGrounded?.Invoke(hit.collider != null);
    }
}
