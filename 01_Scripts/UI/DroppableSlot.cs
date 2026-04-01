using UnityEngine;
using UnityEngine.EventSystems;

public class DroppableSlot : MonoBehaviour, IDropHandler
{
    private RectTransform _rect;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = _rect.position;
        }
    }
}
