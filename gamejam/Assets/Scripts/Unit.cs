using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Unit:MonoBehaviour
{
    public string Name;
    //角色模块列表
    public List<GameModule> Modules;
    //角色的基础属性
    [SerializedDictionary("Base Attribute", "Value")]
    public SerializedDictionary<AttributeType, float> TotalAttributes ;
    [SerializeField]
    private BaseAttributes ba;

    public AttackType damegeType;

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

    private void Update()
    {
        
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

    //受到伤害
    public void TakeDamage(float damage,AttackType attackType)
    {
        float effectiveDamage;
        if (attackType == AttackType.Physic)
        {
            effectiveDamage = Mathf.Max(1.0f, damage - TotalAttributes[AttributeType.PhysicalDefense]);
        }
        else
        {
            effectiveDamage = Mathf.Max(1.0f, damage - TotalAttributes[AttributeType.MagicDefense]);
        }
        TotalAttributes[AttributeType.CurrentHealth]-=effectiveDamage;
        if (TotalAttributes[AttributeType.CurrentHealth] <= 0)
        {
            TotalAttributes[AttributeType.CurrentHealth] = 0;
            Debug.Log($"{Name} has been slained!");
        }
        else
        {
            Debug.Log($"{Name} has been damaged!");
        }
    }
}
