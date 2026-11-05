using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private Mover _playerMover;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Health _health;
    [SerializeField] private Cooldown _cooldown;
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

    private void Update()
    {
        Attack();
        HasEnoughtHealth();
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

    private void Attack()
    {
        if (_inputHandler.MouseButtonDowned && _cooldown.IsReady)
        {
            _attacker.DetectEnemy();
            _animationHandler.SetupAnimationAttack();
            _cooldown.StartCooldown();
        }
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    private void HasEnoughtHealth()
    {
        if (_health.HealthLevel <= 0)
        {
            ExitGame();
        }
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
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            _wallet.AddCoin();
        }

        if (collision.gameObject.TryGetComponent(out HealthBox health))
        {
            _health.Healthing(health.HealingValue);
        }
    }

    public void ExitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
