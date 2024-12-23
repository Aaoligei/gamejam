using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeavyStrike : Skill
{
    public HeavyStrike(string name, GameObject currentUnit, Unit target, float skillRange, bool isAttack, float cooldown,float damage, AttackType damageType) : base(name, currentUnit, target, skillRange, isAttack, cooldown, damage, damageType)
    {
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
                Debug.Log("释放技能'重斩'");
                unit.TakeDamage(damage, damageType);
            }
        }
    }

}
