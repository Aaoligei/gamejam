using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTransform : GameModule
{
    public override void SetAttributes()
    {
        base.SetAttributes();
        Unit unit = GetComponent<Unit>();
        if(unit != null)
        {
            unit.damegeType=AttackType.Magic;
        }
    }
}
