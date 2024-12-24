using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [HideInInspector] public DraggableItem currentItem;
    public Unit belongTo;

    public bool CanAccept(DraggableItem item)
    {
        // 定义哪些物品可以放置在此格子中
        // 可以基于类型、标签或其他条件
        return currentItem == null; // 简单示例：只允许空格子接受新物品
    }

    public void AcceptItem(DraggableItem item)
    {
        if (CanAccept(item))
        {
            // 更新当前格子的内容
            currentItem = item;
            item.transform.SetParent(transform, false);
            item.transform.localPosition = Vector3.zero;
            item.transform.localScale=Vector3.one*4;

            AddModuleToGameObject(item);
        }
    }

    public void RemoveItem()
    {
        // 移除当前格子中的物品
        currentItem = null;
    }


    private void AddModuleToGameObject(DraggableItem item)
    {
        // 实现添加模块的具体逻辑
        // 这可能涉及到修改游戏对象的状态、属性或添加组件
        if(belongTo != null)
        {
            GameModule gameModule=item.GetComponent<GameModule>();
            if (gameModule != null)
            {
                belongTo.AddModule(gameModule);
            }
        } 
    }
}