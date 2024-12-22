using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Unit:MonoBehaviour
{
    //角色模块列表
    public List<GameModule> Modules;
    //角色的基础属性
    [SerializedDictionary("Base Attribute","Value")]
    public SerializedDictionary<AttributeType, float> TotalAttributes;

    //游戏初始化根据自身挂载模块设置属性
    public void Start()
    {
        foreach (var type in System.Enum.GetValues(typeof(AttributeType)))
            TotalAttributes[(AttributeType)type] = 0f;
        foreach(var module in Modules)
        {
            foreach (var attr in module.Attributes)
                TotalAttributes[attr.Key] += attr.Value;
        }
    }
    
    //增加模块
    public void AddModule(GameModule module)
    {
        Modules.Add(module);
        foreach (var attr in module.Attributes)
            TotalAttributes[attr.Key] += attr.Value;
    }

    //使用技能
    public void UseSkill(Skill skill, Unit target)
    {
        skill.Effect(target);
    }
}
