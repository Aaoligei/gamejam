using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Unit:MonoBehaviour
{
    //角色模块列表
    public List<GameModule> Modules;
    //角色的基础属性
    [SerializedDictionary("Base Attribute", "Value")]
    public SerializedDictionary<AttributeType, float> TotalAttributes ;
    [SerializeField]
    private BaseAttributes ba;

    //赋予单位基础属性
    public void Awake()
    {
        TotalAttributes=ba.InitAttributes;
        
    }

    //根据自身挂载模块调整属性
    public void Start()
    {
        foreach (var module in Modules)
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
