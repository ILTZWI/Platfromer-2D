using UnityEngine;

public class Fliper : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _rotateAngle;

    public bool IsTurned { get; private set; }

    public void TurnAsaidSprite(float direction)
    {
        if (direction > 0)
            Flip();
        else if (direction < 0)
            UnFlip();

    }

    private void Flip()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void UnFlip()
    {
        transform.rotation = Quaternion.Euler(0, _rotateAngle, 0);
    }
}
