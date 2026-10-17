using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _positions;
    [SerializeField] private Mover _mover;

    private Rigidbody2D _rigidbody;

    private int _currentPositionIndex = 0;

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
        Transform target = _positions[_currentPositionIndex];

        Move(target);

        if (CompareDistance(target) < 0.1)
        {
            _currentPositionIndex++;

            if (_currentPositionIndex >= _positions.Length)
                _currentPositionIndex = 0;
        }
    }

    private void Move(Transform target)
    {
        _mover.Move(GetDirection(target),_rigidbody);
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
}
