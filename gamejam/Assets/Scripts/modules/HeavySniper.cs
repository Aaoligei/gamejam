using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavySniper : GameModule
{
    public override void SetAttributes()
    {
        base.SetAttributes();
        Attributes[AttributeType.AttackPower] *= 1.5f;
        Attributes[AttributeType.AttackRange] *= 1.5f;
        Attributes[AttributeType.AttackInterval] *= 0.8f;
    }
}
