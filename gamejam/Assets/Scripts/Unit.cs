using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Unit:MonoBehaviour
{
    //��ɫģ���б�
    public List<GameModule> Modules;
    //��ɫ�Ļ�������
    [SerializedDictionary("Base Attribute","Value")]
    public SerializedDictionary<AttributeType, float> TotalAttributes;

    //��Ϸ��ʼ�������������ģ����������
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
}
