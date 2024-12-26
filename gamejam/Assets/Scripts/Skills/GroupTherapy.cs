using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupTherapy : Skill
{
    public GroupTherapy()
    {
        skillData = Resources.Load<SkillData>("groupTherapy");
    }

    public override void Excute()
    {
        base.Excute();

    }
}
