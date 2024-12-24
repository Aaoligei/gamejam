using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [HideInInspector] public DraggableItem currentItem;
    public Unit belongTo;
    public bool isBag=false;

    public bool CanAccept(DraggableItem item)
    {
        // ������Щ��Ʒ���Է����ڴ˸�����
        // ���Ի������͡���ǩ����������
       if(currentItem == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AcceptItem(DraggableItem item)
    {
        if (CanAccept(item))
        {
            // ���µ�ǰ���ӵ�����
            currentItem = item;
            item.transform.SetParent(transform, false);
            item.transform.localPosition = Vector3.zero;
            item.transform.localScale=Vector3.one*4;

            AddModuleToGameObject(item);
        }
    }

    public void RemoveItem()
    {
        // �Ƴ���ǰ�����е���Ʒ
        RemoveModulFromGameObject(currentItem);
        currentItem = null;
    }


    private void AddModuleToGameObject(DraggableItem item)
    {
        // ʵ�����ģ��ľ����߼�
        // ������漰���޸���Ϸ�����״̬�����Ի�������
        if(belongTo != null)
        {
            GameModule gameModule=item.GetComponent<GameModule>();
            if (gameModule != null)
            {
                belongTo.AddModuleDynamic(gameModule);
            }
        } 
    }

    private void RemoveModulFromGameObject(DraggableItem item)
    {
        if(belongTo != null)
        {
            GameModule gameModule = item.GetComponent<GameModule>();
            if (gameModule != null)
            {
                belongTo.RemoveModule(gameModule);
            }
        }
    }
}