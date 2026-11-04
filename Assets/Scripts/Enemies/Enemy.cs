using UnityEngine;
using UnityEngine.SearchService;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Cooldown _cooldown;
    [SerializeField] private DetectionZone _detectionZone;
    [SerializeField] private Transform[] _positions;
    [SerializeField] private EnemyAnimationHandler _animationHandler;
    [SerializeField] private Fliper _fliper;
    [SerializeField] private Health _health;

    private Rigidbody2D _rigidbody;
    private Transform _positionEnemy;

    private bool _isDetected;
    private bool _isAlive;

    private int _currentPositionIndex = 0;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        HasEnoughHealth();
    }

    private void OnEnable()
    {
        _detectionZone.Detected += OnDetected;
    }

    private void OnDisable()
    {
        _detectionZone.Detected -= OnDetected;
    }

    private void Move()
    {
        if (_isDetected == false)
        {
            Transform target = _positions[_currentPositionIndex];

            _mover.Move(GetDirection(target), _rigidbody);
            _fliper.TurnAsaidSprite(GetDirection(target));

            if (CompareDistance(target) < 0.1)
            {
                _currentPositionIndex++;

                if (_currentPositionIndex >= _positions.Length)
                    _currentPositionIndex = 0;
            }
        }
        else
        {
            Chase();
        }
    }

    private void OnDetected(Player player, bool detected)
    {
        _positionEnemy = player.transform;
        _isDetected = detected;
        Attack();
    }

    private void Chase()
    {
        _mover.Move(GetDirection(_positionEnemy), _rigidbody);
        _fliper.TurnAsaidSprite(GetDirection(_positionEnemy));
    }

    private void Attack()
    {
        if (_detectionZone.IsDetected && _cooldown.IsReady)
        {
            _animationHandler.SetupAnimationAttack();
            _attacker.DetectEnemy();
            _cooldown.StartCooldown();
        }
    }

    private void HasEnoughHealth()
    {
        if (_health.HealthLevel <= 0)
        {
            Destroy(gameObject);
        }
    }

    private float GetDirection(Transform target)
    {
        float direction = target.position.x - _rigidbody.transform.position.x;
        return direction;
    }

    private float CompareDistance(Transform target)
    {
        float distance = (_rigidbody.transform.position - target.position).sqrMagnitude;
        return distance;
    }

    public void TakeDamage(int enemyDamage)
    {
        _health.TakeDamage(enemyDamage);
        Debug.Log(_health + "enemy");
    }
}
