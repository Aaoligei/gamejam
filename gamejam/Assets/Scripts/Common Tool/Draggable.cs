using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableModule : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private GameModule module;
    public GameObject MGO;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        module=GetComponent<GameModule>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / rectTransform.root.localScale.x;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        //射线检测
        RaycastHit2D hit = Physics2D.Raycast(eventData.pointerCurrentRaycast.worldPosition, Vector2.zero);
        Debug.Log(hit.collider);
        if (hit.collider != null && hit.collider.CompareTag("Unit"))
        {
            Debug.Log("击中物体");
            Unit unit = hit.collider.GetComponentInParent<Unit>();
            if (unit != null)
            {
                unit.AddModule(module);
                canvasGroup.alpha = 0f;
            }
        }
    }
}