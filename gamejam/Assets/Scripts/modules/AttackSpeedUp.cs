using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedUp : GameModule
{
    public override void SetAttributes()
    {
        base.SetAttributes();
        Attributes[AttributeType.AttackInterval] *= 0.8f;
    }
}
