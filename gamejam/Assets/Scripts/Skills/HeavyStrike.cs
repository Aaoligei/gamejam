using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeavyStrike : Skill
{
    public HeavyStrike()
    {
        skillData=Resources.Load<SkillData>("heavyStrike");
    }

    public override void Excute()
    {
        base.Excute();
        
        Collider2D coll = CharacterBehaviorTool.AttackRangeCheck(currentUnit.transform, skillRange, "enemy");
        if (coll != null)
        {
            Unit unit = coll.GetComponentInParent<Unit>();
            
            if (unit != null)
            {
                Debug.Log($"ÊÍ·Å¼¼ÄÜ'{Name}'");
                unit.TakeDamage(damage, damageType);
            }
        }
    }

}
