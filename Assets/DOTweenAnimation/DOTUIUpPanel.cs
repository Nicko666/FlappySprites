using DG.Tweening;
using UnityEngine;

public class DOTUIUpPanel : DOTUI
{
    [SerializeField] RectTransform rectTransform;

    private void Awake()
    {
        if ( rectTransform == null )
            rectTransform = GetComponent<RectTransform>();
    }

    public override void Close()
    {
        rectTransform.DOPivotY(0, DOTUISystem.speed).SetUpdate(true);
    }

    public override void Open()
    {
        rectTransform.DOPivotY(1, DOTUISystem.speed).SetUpdate(true);
    }

}
