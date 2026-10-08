using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CheckIsGround : MonoBehaviour
{
    [SerializeField] private Transform _startRay;

    public event Action<bool> IsGrounded;

    private bool _isGrounded;

    private void Update()
    {
        CheckGround();
    }

    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(_startRay.position, Vector2.down, 0.07f);


        Debug.DrawRay(
        _startRay.position,
        Vector2.down * 0.07f,
        Color.red
    );

        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent(out Ground ground))
            {
                Debug.Log("True");
                IsGrounded?.Invoke(true);
            }
            else
            {
                Debug.Log("False");
                IsGrounded?.Invoke(false);
            }
        }
        else
        {
            IsGrounded?.Invoke(false);
        }
    }
}
