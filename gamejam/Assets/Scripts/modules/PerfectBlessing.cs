using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectBlessing : GameModule
{
    public override void SetAttributes()
    {
        base.SetAttributes();
        Attributes[AttributeType.AttackPower] *= 1.2f;
        Attributes[AttributeType.HealthCap] *= 1.2f;
        Attributes[AttributeType.CurrentHealth] *= 1.2f;
        Attributes[AttributeType.MagicDefense] += 1;
        Attributes[AttributeType.PhysicalDefense] += 1;
    }
}
