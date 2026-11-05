using UnityEngine;

public class AnimatorData
{
    public static class AnimationsParams
    {
        public static readonly int Speed = Animator.StringToHash(nameof(Speed));
        public static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
    }
}
