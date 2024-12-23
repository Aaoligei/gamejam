using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttributeType
{
    HealthCap, // 生命上限
    CurrentHealth, // 当前生命值
    PhysicalDefense, // 物理防御
    MagicDefense, // 魔法防御
    AttackPower, // 攻击力
    AttackInterval, // 攻击间隔
    AttackRange, // 攻击距离
    MoveSpeed, // 移动速度
    AttackMultiplier,//攻击力系数
    AttackAreaMultiplier//攻击范围系数
}

public enum AttackType
{
    Physic,//物理攻击
    Magic,//魔法攻击
    TrueDamage,//真实伤害
    Heal//治疗
}

[CreateAssetMenu(fileName = "New Base Attributes", menuName = "Attributes")]
public class BaseAttributes : ScriptableObject
{
    [SerializedDictionary("Base Attribute", "Value")]
    public SerializedDictionary<AttributeType, float> InitAttributes;//基础属性
    public string description;//描述文本
}

public interface ISkillModule
{
    void Process(Skill skill);
}