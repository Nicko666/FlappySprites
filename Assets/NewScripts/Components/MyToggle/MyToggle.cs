using System;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyToggle : MonoBehaviour, IPointerClickHandler
{
    public Action onClick;

    [SerializeField] private Animator _animator;
    [SerializeField] private SVGImage _image;

    private const string ToggledBool = "Toggled";

    public void OutputImage(Sprite sprite) =>
        _image.sprite = sprite;

    public void OutputToggled(bool value) =>
        _animator.SetBool(ToggledBool, value);

    public void OnPointerClick(PointerEventData eventData) =>
        onClick?.Invoke();
}

