using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Slot ParentSlot;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
                            
    public void OnBeginDrag(PointerEventData eventData)
    {
        // 开始拖动时增加透明度并允许排序在其他UI元素之上
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
        
        transform.parent=null;

        Slot slot = FindSlotUnderMouse(eventData);
        if (slot!=null){
            slot.RemoveItem();
            ParentSlot = slot;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 根据鼠标位置更新拖动物品的位置
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 结束拖动时恢复默认状态
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

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