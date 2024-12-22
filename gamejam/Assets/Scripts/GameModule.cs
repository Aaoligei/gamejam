using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
