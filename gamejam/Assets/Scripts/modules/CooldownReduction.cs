using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownReduction : GameModule
{
    protected override void AProcess(Skill skill)
    {
        base.AProcess(skill);
        skill.cooldown *=0.8f;
    }
}
