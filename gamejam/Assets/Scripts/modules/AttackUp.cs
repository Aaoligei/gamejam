using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUp : GameModule
{
    public override void SetAttributes()
    {
        base.SetAttributes();
        Attributes[AttributeType.AttackPower] *= 1.1f;
    }
}
