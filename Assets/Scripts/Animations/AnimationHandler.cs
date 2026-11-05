using UnityEngine;

public class AnimationHandler : MonoBehaviour
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
        float speed = _animator.GetFloat(AnimatorData.AnimationsParams.Speed);
        bool isGrounded = _animator.GetBool(AnimatorData.AnimationsParams.IsGrounded);
    }

    private void SetupAnimations(float speed, bool isGrounded, int stepsAmount, bool shouldAttack)
    {
        _animator.SetFloat(AnimatorData.AnimationsParams.Speed, speed);
        _animator.SetBool(AnimatorData.AnimationsParams.IsGrounded, isGrounded);
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
