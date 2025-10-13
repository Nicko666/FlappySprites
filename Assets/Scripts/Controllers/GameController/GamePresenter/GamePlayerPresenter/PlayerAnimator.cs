using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private const string animatorMoveFloat = "MoveY";

    internal void OutputMoveY(float value) =>
        _animator.SetFloat(animatorMoveFloat, value);

    internal void OutputRuntimeAnimatorController(RuntimeAnimatorController runtimeAnimatorController) =>
        _animator.runtimeAnimatorController = runtimeAnimatorController;
}
