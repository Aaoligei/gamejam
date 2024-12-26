using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedingAttack : GameModule
{
    public override void SetAttributes()
    {
        base.SetAttributes();
        Attributes[AttributeType.AttackInterval] /= 2;
        Attributes[AttributeType.AttackRange] *= 1.5f;
        Attributes[AttributeType.AttackPower] *= 0.8f;
    }
}
