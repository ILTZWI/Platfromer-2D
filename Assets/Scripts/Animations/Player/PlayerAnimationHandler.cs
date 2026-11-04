using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    private const string Speed = "Speed";
    private const string IsGround = "IsGrounded";
    private const string Jump = "Jump";
    private const string Attack = "Attack";

    [SerializeField] private Animator _animator;

    public void SetMoveSpeed(Rigidbody2D rigidbody2D)
    {
        _animator.SetFloat(Speed, Mathf.Abs(rigidbody2D.linearVelocity.x));
    }

    public void SetGroundPositon(bool isGround)
    {
        _animator.SetBool(IsGround, isGround);
    }
    private void LogParametersAnimator()
    {
        float speed = _animator.GetFloat(PlayerAnimatorData.PlayerAnimationsParams.Speed);
        bool isGrounded = _animator.GetBool(PlayerAnimatorData.PlayerAnimationsParams.IsGrounded);
    }

    private void SetupAnimations(float speed, bool isGrounded, int stepsAmount, bool shouldAttack)
    {
        _animator.SetFloat(PlayerAnimatorData.PlayerAnimationsParams.Speed, speed);
        _animator.SetBool(PlayerAnimatorData.PlayerAnimationsParams.IsGrounded, isGrounded);
    }

    public void SetupAnimationAttack()
    {
        _animator.SetTrigger(Attack);
    }

    public void SetupAnimationJump()
    {
        _animator.SetTrigger(Jump);
    }
}
