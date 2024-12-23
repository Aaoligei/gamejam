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

public enum AttackType
{
    Physic,//������
    Magic//ħ������
}

[CreateAssetMenu(fileName = "New Base Attributes", menuName = "Attributes")]
public class BaseAttributes : ScriptableObject
{
    [SerializedDictionary("Base Attribute", "Value")]
    public SerializedDictionary<AttributeType, float> InitAttributes;
}

public interface ISkillModule
{
    void Process(Skill skill);
}