using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttributeType
{
    HealthCap, // ��������
    CurrentHealth, // ��ǰ����ֵ
    PhysicalDefense, // �������
    MagicDefense, // ħ������
    AttackPower, // ������
    AttackInterval, // �������
    AttackRange, // ��������
    MoveSpeed, // �ƶ��ٶ�
}
//����ģ��
public class GameModule:MonoBehaviour
{
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
