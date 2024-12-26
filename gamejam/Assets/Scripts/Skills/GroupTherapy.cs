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

        Collider2D coll = CharacterBehaviorTool.AttackRangeCheck(currentUnit.transform, skillRange, "Unit");

        if (coll != null)
        {
            List<Collider2D> targets = CharacterBehaviorTool.SurroundCheck(coll.transform, skillArea, "Unit");
            if (targets != null)
            {
                foreach (Collider2D target in targets)
                {
                    Unit unit = target.GetComponentInParent<Unit>();
                    if (unit != null)
                    {
                        Debug.Log($"{currentUnit.GetComponent<Unit>().Name}ÊÍ·Å¼¼ÄÜ'{Name}'");
                        unit.TakeDamage(damage, AttackType.Heal);
                    }
                }
            }
        }
    }
}
