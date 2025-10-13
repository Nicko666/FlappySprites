using System;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Animator _animator;
    //[SerializeField] private Panel[] _childPanels;

    private const string OpenBool = "Open";
    
    public Action<bool> onPanelOpen;

    public void OutputOpen(bool value)
    {
        //Array.ForEach(_childPanels, i => i.OutputOpen(false));
     
        _canvasGroup.interactable = value;
        _canvasGroup.blocksRaycasts = value;

        _animator?.SetBool(OpenBool, value);

        onPanelOpen?.Invoke(value);
    }
}
