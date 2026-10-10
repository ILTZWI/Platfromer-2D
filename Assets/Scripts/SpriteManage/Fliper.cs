using UnityEditor.Tilemaps;
using UnityEngine;

public class Fliper : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public bool IsTurned {  get; private set; }

    public void Flip()
    {
        _spriteRenderer.flipX = false;
    }

    public void UnFlip()
    {
        _spriteRenderer.flipX = true;
    }
}
