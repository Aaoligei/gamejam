using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameModule:MonoBehaviour,ISkillModule
{
    public string Name;
    [SerializedDictionary("Base Attribute", "Value")]
    public SerializedDictionary<AttributeType, float> Attributes;

    public void ChangeAttribute(AttributeType type, float value)
    {
        if (Attributes.ContainsKey(type))
            Attributes[type] += value;
        else
            Attributes[type] = value;
    }

    public void Process(Skill skill)
    {
        AProcess(skill);
    }

    protected virtual void AProcess(Skill skill) { }
}
