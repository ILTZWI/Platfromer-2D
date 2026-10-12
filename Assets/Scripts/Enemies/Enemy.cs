using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private Fliper _fliper;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private bool _isRichedPoint = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
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
        _rigidbody.linearVelocity = GetDirection(target) * _speed;
    }

    private Vector2 GetDirection(Transform target)
    {
        Vector2 direction = target.position - _rigidbody.transform.position; 
        return direction.normalized;
    }

    private float CompareDistance(Transform target)
    {
        float distance = (_rigidbody.transform.position - target.position).sqrMagnitude;
        return distance;
    }
}
