using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Unit:MonoBehaviour
{
    public string Name;
    //��ɫģ���б�
    public List<GameModule> Modules;
    //��ɫ�Ļ�������
    [SerializedDictionary("Base Attribute", "Value")]
    public SerializedDictionary<AttributeType, float> TotalAttributes ;
    [SerializeField]
    private BaseAttributes ba;

    public Skill SkillModule;
    public AttackType damegeType;

    public HealthBar healthBar;

    //���赥λ��������
    public void Awake()
    {
        TotalAttributes=ba.InitAttributes;
        
    }

    //������������ģ���������
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
    }

    private void Update()
    {
        healthBar.MaxValue = TotalAttributes[AttributeType.HealthCap];
    }

    //����ģ��
    public void AddModule(GameModule module)
    {
        Modules.Add(module);
        foreach (var attr in module.Attributes)
            TotalAttributes[attr.Key] += attr.Value;
    }

    //ʹ�ü���
    public void UseSkill(Skill skill, Unit target)
    {
        skill.Effect(target);
    }

    //�ܵ��˺�
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
            Debug.Log($"{Name} has been slained!");
        }
        else
        {
            Debug.Log($"{Name} has been damaged!");
        }
    }
}
