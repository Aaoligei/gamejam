using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyStrike : Skill
{
    public float damage=100;
    public AttackType damageType=AttackType.Physic;
    public void Excute()
    {
        Collider2D coll = CharacterBehaviorTool.AttackRangeCheck(transform,skillRange,"enemy");
        if(coll != null)
        {
            Unit unit = coll.GetComponent<Unit>();
            if(unit != null)
            {
                unit.TakeDamage(damage,damageType);
            }
        }
    }
}
