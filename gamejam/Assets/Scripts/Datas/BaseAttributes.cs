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
    AttackMultiplier,//������ϵ��
    AttackAreaMultiplier//������Χϵ��
}

public enum AttackType
{
    Physic,//������
    Magic,//ħ������
    TrueDamage,//��ʵ�˺�
    Heal//����
}

[CreateAssetMenu(fileName = "New Base Attributes", menuName = "Attributes")]
public class BaseAttributes : ScriptableObject
{
    [SerializedDictionary("Base Attribute", "Value")]
    public SerializedDictionary<AttributeType, float> InitAttributes;//��������
    public string description;//�����ı�
}

public interface ISkillModule
{
    void Process(Skill skill);
}