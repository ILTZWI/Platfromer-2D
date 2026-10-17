using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const KeyCode JumpKey = KeyCode.Space;

    public float Direction {  get; private set; }
    public bool JumpKeyDowned { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxisRaw(HorizontalAxis);
        ProcessJumpKey();
    }

    private void ProcessJumpKey()
    {
        JumpKeyDowned = Input.GetKey(JumpKey);
    }
}
