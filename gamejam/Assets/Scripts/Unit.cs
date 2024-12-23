using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Unit:MonoBehaviour
{
    public string Name;
    public List<GameModule> Modules;
    [SerializedDictionary("Base Attribute", "Value")]
    public SerializedDictionary<AttributeType, float> TotalAttributes ;
    [SerializeField]
    private BaseAttributes ba;

    public Skill skill = null;
    public AttackType damegeType;

    public HealthBar healthBar;

    public void Awake()
    {
        TotalAttributes=ba.InitAttributes;
        
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
        skill = new HeavyStrike("heavyStrike", this.gameObject, null, 15.0f, true, 1.0f, 10.0f);
    }

    private void Update()
    {
        healthBar.MaxValue = TotalAttributes[AttributeType.HealthCap];

        
    }

    //增加模块
    public void AddModule(GameModule module)
    {
        Modules.Add(module);
        foreach (var attr in module.Attributes)
            TotalAttributes[attr.Key] += attr.Value;
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
        healthBar.Change(-effectiveDamage);
        if (TotalAttributes[AttributeType.CurrentHealth] <= 0)
        {
            TotalAttributes[AttributeType.CurrentHealth] = 0;
            Debug.Log($"{Name} 被击杀！");
        }
        else
        {
            Debug.Log($"{Name} 受到{effectiveDamage}伤害!");
        }
    }
}
