using UnityEngine;

public class EnemyAnimationHandler : MonoBehaviour
{
    private const string Speed = "Speed";
    private const string Attack = "Attack";

    [SerializeField] private Animator _animator;

    public void SetMoveSpeed(Rigidbody2D rigidbody2D)
    {
        _animator.SetFloat(Speed, Mathf.Abs(rigidbody2D.linearVelocity.x));
    }

    private void LogParametersAnimator()
    {
        float speed = _animator.GetFloat(PlayerAnimatorData.PlayerAnimationsParams.Speed);
    }

    private void SetupAnimations(float speed, bool isGrounded, int stepsAmount, bool shouldAttack)
    {
        _animator.SetFloat(PlayerAnimatorData.PlayerAnimationsParams.Speed, speed);
    }

    public void SetupAnimationAttack()
    {
        _animator.SetTrigger(Attack);
    }
}
