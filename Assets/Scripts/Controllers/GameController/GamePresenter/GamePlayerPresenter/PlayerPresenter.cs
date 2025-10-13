using System;
using UnityEngine;

internal class PlayerPresenter : MonoBehaviour
{
    [SerializeField] private PlayerCollider _playerCollider;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private float _jumpForce;

    internal event Action onInputDie
    {
        add => _playerCollider.onInputObstacle += value;
        remove => _playerCollider.onInputObstacle -= value;
    }
    internal event Action onInputAddPointsModel
    {
        add => _playerCollider.onInputPoint += value;
        remove => _playerCollider.onInputPoint -= value;
    }
    internal Action onInputClearPointsModel;

    internal void OutputIdol()
    {
        onInputClearPointsModel.Invoke();

        _playerCollider.transform.localPosition = Vector3.zero;
        _playerCollider.enabled = false;
    }

    internal void OutputPlay()
    {
        _playerCollider.transform.localPosition = Vector3.zero;
        _playerCollider.enabled = true;
    }

    internal void OutputPause()
    {
        _playerCollider.enabled = false;
    }

    internal void OutputPlayerThemeModel(PlayerThemeModel playerThemeModel) =>
        _playerAnimator.OutputRuntimeAnimatorController(playerThemeModel.RuntimeAnimatorController);
    
    internal void OutputJump() =>
        _playerCollider.OutputJump(_jumpForce);

    private void Awake() =>
        _playerCollider.onInputMoveX += OutputMoveY;
    private void OnDestroy() =>
        _playerCollider.onInputMoveX -= OutputMoveY;

    private void OutputMoveY(float value) =>
        _playerAnimator.OutputMoveY(value);
}