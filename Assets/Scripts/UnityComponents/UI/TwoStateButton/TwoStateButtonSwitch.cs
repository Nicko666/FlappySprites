using UnityEngine.EventSystems;

public class TwoStateButtonSwitch : TwoStateButton, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Enable = !enable;
    }

}
