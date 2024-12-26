using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleHealth : GameModule
{
    public override void SetAttributes()
    {
        base.SetAttributes();
        Attributes[AttributeType.HealthCap] *= 1.1f;
        Attributes[AttributeType.CurrentHealth] *= 1.1f;
    }

}
