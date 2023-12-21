using DG.Tweening;
using UnityEngine;

public class DOTUISpinAnimation : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;

    public void Spin(int value)
    {
        rectTransform.DOLocalRotate(Vector3.forward * value, DOTUISystem.duration, RotateMode.FastBeyond360).SetUpdate(true);
    }

}
