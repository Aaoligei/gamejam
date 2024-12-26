using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeUp : GameModule
{
    public override void SetAttributes()
    {
        base.SetAttributes();
        Attributes[AttributeType.AttackRange] *= 1.5f;
    }
}
