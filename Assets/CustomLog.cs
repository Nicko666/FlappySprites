using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class CustomLog : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] CanvasGroup canvasGroup;

    
    public void Log(string message)
    {
        canvasGroup.DOKill();
        canvasGroup.alpha = 1;
        text.text = message;
        canvasGroup.DOFade(0f, 10f);
        //StartCoroutine(Disable(10));
    }

    IEnumerator Disable(float time)
    {
        yield return new WaitForSeconds(time);
        text.gameObject.SetActive(false);
    }

    public void Example()
    {
        Log("CustomLogExample");
    }

}
