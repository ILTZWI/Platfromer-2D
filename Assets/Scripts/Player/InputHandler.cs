using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const KeyCode JumpKey = KeyCode.Space;
    private const KeyCode FireButton = KeyCode.Mouse0;

    public float Direction {  get; private set; }
    public bool JumpKeyDowned { get; private set; }
    public bool MouseButtonDowned { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxisRaw(HorizontalAxis);
        ProcessJumpKey();
        ProcessMouseButtonDowned();
    }

    private void ProcessJumpKey()
    {
        JumpKeyDowned = Input.GetKey(JumpKey);
    }

    private void ProcessMouseButtonDowned()
    {
        MouseButtonDowned = Input.GetKeyDown(FireButton);
    }
}
