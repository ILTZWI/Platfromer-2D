using Unity.VisualScripting;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpHeight;

    public void Move(float direction, Rigidbody2D rigidbody)
    {
        rigidbody.linearVelocity = new Vector2(direction * _moveSpeed, rigidbody.linearVelocity.y);
    }

    public void Jump(Rigidbody2D rigidbody2D)
    {
        rigidbody2D.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Impulse);
    }
}
