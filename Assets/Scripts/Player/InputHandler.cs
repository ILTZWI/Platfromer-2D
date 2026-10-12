using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const KeyCode JumpKey = KeyCode.Space;

    public float MoveInput {  get; private set; }

    public event Action JumpKeyDowned;

    private void Update()
    {
        MoveInput = Input.GetAxisRaw(HorizontalAxis);
        ProcessJumpKey();
    }

    private void ProcessJumpKey()
    {
        if (Input.GetKeyDown(JumpKey)) 
        {
            JumpKeyDowned?.Invoke();
        }
    }
}
