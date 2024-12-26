using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Slot ParentSlot;
    public GameObject theParent;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
                            
    public void OnBeginDrag(PointerEventData eventData)
    {

        rectTransform= GetComponentInParent<RectTransform>();

        Slot slot = FindSlotUnderMouse(eventData);
        if (slot!=null){
            slot.RemoveItem();
            ParentSlot = slot;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 根据鼠标位置更新拖动物品的位置
        //rectTransform.anchoredPosition += eventData.delta;
        transform.position += new Vector3(eventData.delta.x,eventData.delta.y,0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        // 尝试找到一个合适的格子进行吸附
        Slot slot = FindSlotUnderMouse(eventData);
        if (slot != null && slot.CanAccept(this))
        {
            // 如果找到了格子并且可以接受该物品，则吸附到格子中
            slot.AcceptItem(this);
            ParentSlot = slot;
        }
        else
        {
            // 否则返回原位
            ResetPosition();
        }
    }

    private Slot FindSlotUnderMouse(PointerEventData eventData)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = eventData.position;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (var result in results)
        {
            Slot slot = result.gameObject.GetComponent<Slot>();
            if (slot != null)
                return slot;
        }

        return null;
    }

    private void ResetPosition()
    {
        // 返回原始位置的方法
        // 这里可以根据实际情况调整
        rectTransform.anchoredPosition = Vector2.zero;
        ParentSlot.AcceptItem(this);
    }
}