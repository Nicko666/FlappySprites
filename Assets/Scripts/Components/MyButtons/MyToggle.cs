using System;
using UnityEngine;
using UnityEngine.UI;

internal class MyToggle : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] Animator _animator;

    private const string NormalTrigger = "Normal";
    private const string ToggledTrigger = "Toggled";
    private bool _toggled;

    internal Action<MyToggle> onClick;

    internal void OutputIcon(Sprite image) =>
        _button.image.sprite = image;
    
    internal void OutputToggled(bool value)
    {
        _toggled = value;
        _animator.ResetTrigger(_toggled ? NormalTrigger : ToggledTrigger);
        _animator.SetTrigger(_toggled ? ToggledTrigger : NormalTrigger);
    }

    private void Awake() =>
        _button.onClick.AddListener(InputThemeButton);
    private void OnDestroy() =>
        _button.onClick.RemoveListener(InputThemeButton);

    private void OnEnable()
    {
        _animator.SetTrigger(_toggled ? ToggledTrigger : NormalTrigger);
    }

    private void InputThemeButton() =>
        onClick.Invoke(this);
}