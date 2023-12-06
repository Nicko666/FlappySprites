using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DOTUIScaleIn : MonoBehaviour
{
    [SerializeField] Image image;
    
    public void Enable()
    {
        transform.DOScale(Vector3.one * 0.5f, DOTUISystem.speed).SetUpdate(true);
        image.DOFade(0.7f, DOTUISystem.speed);
    }

    public void Disble()
    {
        transform.DOScale(Vector3.one, DOTUISystem.speed).SetUpdate(true);
        image.DOFade(0.0f, DOTUISystem.speed);
    }

}
