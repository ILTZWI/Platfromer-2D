using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerJump _playerJump;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Animator _animator;

    private bool _isGround;

    private void Update()
    {
        _animator.SetFloat("Speed", Mathf.Abs(_playerMover.Rigidbody.linearVelocity.x));
        _animator.SetBool("IsGrounded", _isGround);
    }

    private void OnEnable()
    {
        _groundChecker.OnGrounded += OnGround;
        _playerJump.OnSetupAnimationJump += OnSetupAnimationJump;
    }

    private void OnDisable()
    {
        _groundChecker.OnGrounded -= OnGround;
        _playerJump.OnSetupAnimationJump -= OnSetupAnimationJump;
    }

    private void OnGround(bool isGround)
    {
        _isGround = isGround;
    }

    private void OnSetupAnimationJump()
    {
        SetupAnimationJump();
    }

    private void LogParametersAnimator()
    {
        float speed = _animator.GetFloat(PlayerAnimatorData.Params.Speed);
        bool isGrounded = _animator.GetBool(PlayerAnimatorData.Params.IsGrounded);
    }

    private void SetupAnimations(float speed, bool isGrounded, int stepsAmount, bool shouldAttack)
    {
        _animator.SetFloat(PlayerAnimatorData.Params.Speed, speed);
        _animator.SetBool(PlayerAnimatorData.Params.IsGrounded, isGrounded);
    }

    public void SetupAnimationJump()
    {
        _animator.SetTrigger("Jump");
    }
}
