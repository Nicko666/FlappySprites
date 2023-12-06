using UnityEngine;
using UnityEngine.Events;

public abstract class TwoStateButton : MonoBehaviour
{
    protected bool enable;
    public bool Enable
    {
        get => enable;
        set
        {
            enable = value;

            if (value)
            {
                onEnable?.Invoke();
            }
            else
            {
                onDisable?.Invoke();
            }
        }
    }

    public UnityEvent onEnable;
    public UnityEvent onDisable;

}
