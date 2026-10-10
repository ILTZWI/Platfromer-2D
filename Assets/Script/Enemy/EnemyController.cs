using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private Fliper _fliper;
    [SerializeField] private float _speed;
    [SerializeField] private Enemy _enemy;

    private Rigidbody _rigidbody;

    private bool _isRichedPoint = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        Transform target;

        if(_isRichedPoint)
        {
            target = _startPosition;
            _fliper.UnFlip();
        }
        else
        {
            target = _targetPosition;
            _fliper.Flip();
        }

        Move(target);

        if(CompareDistance(target)  < 1) 
            _isRichedPoint = _isRichedPoint ? false : true;
    }

    private void Move(Transform target)
    {
        _enemy.Rigidbody.linearVelocity = GetDirection(target) * _speed;
    }

    private Vector2 GetDirection(Transform target)
    {
        Vector2 direction = target.position - _enemy.transform.position; 
        return direction.normalized;
    }

    private float CompareDistance(Transform target)
    {
        float distance = (_enemy.transform.position - target.position).sqrMagnitude;
        return distance;
    }
}
