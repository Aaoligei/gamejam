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
}

public enum AttackType
{
    Physic,//物理攻击
    Magic//魔法攻击
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