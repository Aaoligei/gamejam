using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDefenceUp : GameModule
{
    public override void SetAttributes()
    {
        base.SetAttributes();
        Attributes[AttributeType.MagicDefense] += 1;
    }
}
