using System.Collections.Generic;
using UnityEngine;

public class FireBall : Skill
{
    public GameObject fireBall;
    
    public FireBall()
    {
        skillData = Resources.Load<SkillData>("fireBall");
    }

    public override void Excute()
    {
        base.Excute();
        Debug.Log("»ðÇòÊõ£¡£¡£¡£¡£¡£¡");
        Collider2D coll = CharacterBehaviorTool.AttackRangeCheck(currentUnit.transform, skillRange, "enemy");

        if (coll != null)
        {
            SkillManager.Instance.GenrateFireBall(coll,this);
        }
    }
}