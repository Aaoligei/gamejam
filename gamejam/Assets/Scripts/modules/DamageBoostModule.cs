using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoostModule : GameModule
{
    protected override void AProcess(Skill skill)
    {
        base.AProcess(skill);
        skill.damage *= 2;
    }
}
