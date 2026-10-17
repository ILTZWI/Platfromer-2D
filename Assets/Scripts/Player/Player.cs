using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private Mover _playerMover;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private AnimationHandler _animationHandler;
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private Fliper _fliper;
    [SerializeField] private Wallet _wallet;

    public Rigidbody2D Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ProccesMove();

        _animationHandler.SetMoveSpeed(Rigidbody);
        _animationHandler.SetGroundPositon(_groundDetector.IsGrounded);

        _fliper.TurnAsaidSprite(_inputHandler.Direction);
    }

    private void OnEnable()
    {
        _collisionHandler.Encountered += OnEncounterd;
    }

    private void OnDisable()
    {
        _collisionHandler.Encountered -= OnEncounterd;
    }

    private void ProccesMove()
    {
        if (_inputHandler.Direction != 0)
        {
            _playerMover.Move(_inputHandler.Direction, Rigidbody);
        }

        if (_inputHandler.JumpKeyDowned && _groundDetector.IsGrounded)
        {
            _playerMover.Jump(Rigidbody);
            _animationHandler.SetupAnimationJump();
        }
    }

    private void OnEncounterd(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Coin coin))
        {
            _wallet.AddCoin();
        }
    }
}
