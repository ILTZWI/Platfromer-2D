using UnityEngine;

public class CanvasRotation : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }
}