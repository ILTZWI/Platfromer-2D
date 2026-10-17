using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private Transform _positionDetector;
    [SerializeField] private float _detectRadius;
    [SerializeField] private LayerMask _groundLayer;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        Detect();
    }

    private void Detect()
    {
        IsGrounded = Physics2D.OverlapCircle
            (
                _positionDetector.position,
                _detectRadius,
                _groundLayer
            );
    }

    private void OnDrawGizmosSelected()
    {
        if (_positionDetector == null)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_positionDetector.position, _detectRadius);
    }
}
