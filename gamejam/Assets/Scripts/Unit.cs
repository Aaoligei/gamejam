using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Unit:MonoBehaviour
{
    public string Name;
    public List<GameModule> Modules;
    [SerializedDictionary("Base Attribute", "Value")]
    public SerializedDictionary<AttributeType, float> TotalAttributes ;
    [SerializeField]
    private BaseAttributes ba;

    public Skill skill ;
    public AttackType damegeType;

    public HealthBar healthBar;

    public void Awake()
    {
        foreach (var attr in ba.InitAttributes)
        {
            TotalAttributes[attr.Key]= attr.Value;
        }
    }

    public void Start()
    {
        foreach (var module in Modules)
        {
            foreach (var attr in module.Attributes)
                TotalAttributes[attr.Key] += attr.Value;
            
        }

        healthBar = GetComponent<HealthBar>();
        healthBar.MaxValue = TotalAttributes[AttributeType.HealthCap];
        healthBar.Value = TotalAttributes[AttributeType.HealthCap];
        //配置技能
        skill = new HeavyStrike();
        skill.InitSkill();
        skill.currentUnit = this.gameObject;
        //技能管线
        foreach(var module in Modules)
        {
            module.Process(skill);
        }
    }

    private void Update()
    {
        healthBar.MaxValue = TotalAttributes[AttributeType.HealthCap];
    }

    //动态增加模块
    public void AddModuleDynamic(GameModule module)
    {
        Modules.Add(module);
        foreach (var attr in module.Attributes)
            TotalAttributes[attr.Key] += attr.Value;
        module.Process(skill);
    }

    //静态增加模块
    public void AddModuleStatic(GameModule module)
    {
        Modules.Add(module);
    }

    public void RemoveModule(GameModule module)
    {
        if(Modules.Contains(module))
            Modules.Remove(module);
    }

    //受到伤害
    public void TakeDamage(float damage,AttackType attackType)
    {
        float effectiveDamage=0;
        if (attackType == AttackType.Physic)
        {
            effectiveDamage = Mathf.Max(1.0f, damage - TotalAttributes[AttributeType.PhysicalDefense]);
        }
        else if(attackType==AttackType.Magic)
        {
            effectiveDamage = Mathf.Max(1.0f, damage - TotalAttributes[AttributeType.MagicDefense]);
        }else if(attackType==AttackType.Heal)
        {
            effectiveDamage = -damage;
        }
        else if(attackType == AttackType.TrueDamage)
        {
            effectiveDamage = damage;
        }
        TotalAttributes[AttributeType.CurrentHealth]-=effectiveDamage;
        TotalAttributes[AttributeType.CurrentHealth] = Mathf.Clamp(TotalAttributes[AttributeType.CurrentHealth], 0, TotalAttributes[AttributeType.HealthCap]);
        healthBar.Change(-effectiveDamage);
        if (TotalAttributes[AttributeType.CurrentHealth] <= 0)
        {
            TotalAttributes[AttributeType.CurrentHealth] = 0;
            Debug.Log($"{Name} 被击杀！");
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log($"{Name} 受到{effectiveDamage}伤害!");
        }
    }
}
