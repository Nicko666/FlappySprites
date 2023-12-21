using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class DOTUICenterPanel : DOTUI
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] CanvasGroup canvasGroup;

    private void Awake()
    {
        if (rectTransform == null)
            rectTransform = GetComponent<RectTransform>();
    }

    public override void Close()
    {
        rectTransform.DOScale(Vector3.zero, DOTUISystem.duration).SetUpdate(true);
        canvasGroup.DOFade(0, DOTUISystem.duration).SetUpdate(true);
    }

    public override void Open()
    {
        rectTransform.DOScale(Vector3.one, DOTUISystem.duration).SetUpdate(true);
        canvasGroup.DOFade(1, DOTUISystem.duration).SetUpdate(true);
    }

}
