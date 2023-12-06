using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TwoStateButtonClick : TwoStateButton, IPointerClickHandler
{
    public UnityEvent onClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke();
    }

}
