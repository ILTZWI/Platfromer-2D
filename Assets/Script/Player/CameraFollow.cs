using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothSpeed;

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 targetPosition = new Vector3(_target.position.x,transform.position.y,transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, _smoothSpeed * Time.deltaTime);
    }
}
