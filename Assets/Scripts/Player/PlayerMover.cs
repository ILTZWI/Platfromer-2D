using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private GroundChecker _checkIsGround;
    [SerializeField] private float _moveSpeed;
    public Rigidbody2D Rigidbody { get; private set; }

    private bool _isGrounded;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnEnable()
    {
        _checkIsGround.OnGrounded += OnGrounded;
    }

    private void OnDisable()
    {
        _checkIsGround.OnGrounded -= OnGrounded;
    }

    private void OnGrounded(bool state)
    {
        _isGrounded = state;
    }

    private void Move()
    {
        Rigidbody.linearVelocity = new Vector2(_inputHandler.MoveInput * _moveSpeed, Rigidbody.linearVelocity.y);
    }
}
