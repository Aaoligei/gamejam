using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//����ģ��
public class GameModule:MonoBehaviour
{
    public bool isSkill;
    //ģ������
    public string Name { get; private set; }
    //ģ������
    [SerializedDictionary("Base Attribute", "Value")]
    public SerializedDictionary<AttributeType, float> Attributes;

    //ģ�����Ըı�
    public void ChangeAttribute(AttributeType type, float value)
    {
        if (Attributes.ContainsKey(type))
            Attributes[type] += value;
        else
            Attributes[type] = value;
    }

}
