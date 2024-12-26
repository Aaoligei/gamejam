using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Skill
{
    public FireBall()
    {
        skillData = Resources.Load<SkillData>("fireBall");
    }

    public override void Excute()
    {
        base.Excute();
        Collider2D coll = CharacterBehaviorTool.AttackRangeCheck(currentUnit.transform, skillRange, "enemy");

        if (coll != null)
        {
            List<Collider2D> targets = CharacterBehaviorTool.SurroundCheck(coll.transform, skillArea, "enemy");
            if(targets != null)
            {
                foreach(Collider2D target in targets)
                {
                    Unit unit = target.GetComponentInParent<Unit>();
                    if (unit != null)
                    {
                        unit.TakeDamage(damage,AttackType.Magic);
                    }
                }
            }
        }
    }
}
