using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CheckIsGround _checkIsGround;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpHeihgt;
    [SerializeField] private Animator _animator;
    private Rigidbody2D _rigidbody;

    private float _moveInput;

    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");

        _animator.SetFloat("Speed", Mathf.Abs(_rigidbody.linearVelocity.x));
        _animator.SetBool("IsGrounded", _isGrounded);
        Debug.Log(_moveInput);
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void LateUpdate()
    {
        FlipSprite();
    }

    private void OnEnable()
    {
        _checkIsGround.IsGrounded += OnGrounded;
    }

    private void OnDisable()
    {
        _checkIsGround.IsGrounded -= OnGrounded;
    }

    private void OnGrounded(bool state)
    {
        _isGrounded = state;
    }

    private void Move()
    {
        //if (_isGrounded)
            _rigidbody.linearVelocity = new Vector2(_moveInput * _moveSpeed, _rigidbody.linearVelocity.y);
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            _rigidbody.AddForce(Vector2.up * _jumpHeihgt, ForceMode2D.Impulse);
            _animator.SetTrigger("Jump");
        }
    }

    private void FlipSprite()
    {
        if (_rigidbody.linearVelocity.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (_rigidbody.linearVelocity.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}
