using UnityEngine;
using UnityEngine.Events;

public class UI : MonoBehaviour
{
    public UnityEvent onOpen;
    public UnityEvent onClose;

    [HideInInspector]
    public bool open;
    public bool Open
    {
        get { return open; }
        set 
        { 
            if (value)
                onOpen?.Invoke();
            else
                onClose?.Invoke();
            open = value;
        }
    }

    //public void OpenUI()
    //{
    //    Open = true;
    //}

    //public void CloseUI()
    //{
    //    Open = false;
    //}

}
