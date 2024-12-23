using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeavyStrike : Skill
{
    public HeavyStrike(string _name, GameObject _go, Unit _target, float _skillRange, bool _isAttack, float _cooldown, float _damage) : base(_name, _go, _target, _skillRange, _isAttack, _cooldown, _damage)
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
