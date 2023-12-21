using DG.Tweening;
using UnityEngine;

public class DOTUIBounsRect : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;

    float duration;

    public void PlayAnumation()
    {
        duration = DOTUISystem.duration / 2;
        transform.DOScale(Vector3.one * 0.75f, duration).SetUpdate(true);
        transform.DOScale(Vector3.one, duration).SetDelay(duration).SetUpdate(true);

    }

}
