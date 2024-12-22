using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : GameModule
{
    public delegate void SkillEffect(Unit target);
    public SkillEffect Effect { get; private set; }
    public Unit target { get; private set; }
    public float skillRange { get; private set; }
}
