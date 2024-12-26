using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage : Skill
{
    public Rage()
    {
        skillData = Resources.Load<SkillData>("rage");
    }

    public override void Excute()
    {
        base.Excute();

    }
}
