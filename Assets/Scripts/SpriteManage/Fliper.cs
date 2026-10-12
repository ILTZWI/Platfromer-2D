using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Fliper : MonoBehaviour
{
    [SerializeField] InputHandler _inputHandler;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public bool IsTurned {  get; private set; }

    private void LateUpdate()
    {
        TurnAsaidSprite();
    }

    private void TurnAsaidSprite()
    {
        if (_inputHandler.MoveInput > 0)
            Flip();
        else if(_inputHandler.MoveInput < 0)
            UnFlip();

    }

    public void Flip()
    {
        _spriteRenderer.flipX = false;
    }

    public void UnFlip()
    {
        _spriteRenderer.flipX = true;
    }
}
