using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const KeyCode JumpKey = KeyCode.Space;

    public float MoveInput {  get; private set; }

    public event Action JumpKeyDowned;

    private void Update()
    {
        MoveInput = Input.GetAxisRaw("Horizontal");
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
