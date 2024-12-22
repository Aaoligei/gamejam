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
//基本模块
public class GameModule:MonoBehaviour
{
    //模块名称
    public string Name { get; private set; }
    //模块属性
    [SerializedDictionary("Base Attribute", "Value")]
    public SerializedDictionary<AttributeType, float> Attributes;

    //模块属性改变
    public void ChangeAttribute(AttributeType type, float value)
    {
        if (Attributes.ContainsKey(type))
            Attributes[type] += value;
        else
            Attributes[type] = value;
    }
}
