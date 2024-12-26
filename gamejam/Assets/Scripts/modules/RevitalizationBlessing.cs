using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevitalizationBlessing : GameModule
{
    public override void SetAttributes()
    {
        base.SetAttributes();
        if (Attributes != null)
        {
            Attributes[AttributeType.HealthCap] *= 1.75f;
            Attributes[AttributeType.CurrentHealth] *= 1.75f;
            Attributes[AttributeType.PhysicalDefense] -= 1;
            Attributes[AttributeType.PhysicalDefense] = Mathf.Max(Attributes[AttributeType.PhysicalDefense], 0);
        }
    }
}
