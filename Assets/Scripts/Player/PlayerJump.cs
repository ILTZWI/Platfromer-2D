using System;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private AnimationManager _animationManager;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private float _jumpHeihgt;

    private bool _isGrounded;

    public event Action OnSetupAnimationJump; 

    private  void OnEnable()
    {
        _groundChecker.OnGrounded += OnGround;
        _inputHandler.JumpKeyDowned += OnJumpKeyDown;
    }

    private void OnDisable()
    {
        _groundChecker.OnGrounded -= OnGround;
        _inputHandler.JumpKeyDowned -= OnJumpKeyDown;
    }

    private void OnGround(bool OnGround)
    {
        _isGrounded = OnGround;
    }

    private void OnJumpKeyDown()
    {
        Jump();
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _playerMover.Rigidbody.AddForce(Vector2.up * _jumpHeihgt, ForceMode2D.Impulse);
            OnSetupAnimationJump?.Invoke();
        }
    }
}
