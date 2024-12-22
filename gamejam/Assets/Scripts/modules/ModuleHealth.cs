using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleHealth : GameModule
{
    private void Start()
    {
        Attributes[AttributeType.HealthCap] = 100;
    }

}
