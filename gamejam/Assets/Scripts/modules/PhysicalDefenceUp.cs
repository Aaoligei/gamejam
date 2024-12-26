using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalDefenceUp : GameModule
{
    public override void SetAttributes()
    {
        base.SetAttributes();
        Attributes[AttributeType.PhysicalDefense] += 1;
    }
}
