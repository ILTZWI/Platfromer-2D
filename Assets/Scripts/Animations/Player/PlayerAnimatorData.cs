using UnityEngine;

public class PlayerAnimatorData
{
    public static class PlayerAnimationsParams
    {
        public static readonly int Speed = Animator.StringToHash(nameof(Speed));
        public static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
    }
}
