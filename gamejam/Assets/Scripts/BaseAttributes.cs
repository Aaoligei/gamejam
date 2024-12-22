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

[CreateAssetMenu(fileName = "New Base Attributes", menuName = "Attributes")]
public class BaseAttributes : ScriptableObject
{
    [SerializedDictionary("Base Attribute", "Value")]
    public SerializedDictionary<AttributeType, float> InitAttributes;
}
