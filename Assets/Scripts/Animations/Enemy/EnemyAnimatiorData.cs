using UnityEngine;

public class EnemyAnimatorData : MonoBehaviour
{
    public static class EnemyAnimationsParams
    {
        public static readonly int Speed = Animator.StringToHash(nameof(Speed));
        public static readonly int IsGround = Animator.StringToHash(nameof(IsGround));
    }
}
