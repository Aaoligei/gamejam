using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterBehaviorTool
{
    //判读是否在攻击范围之类 参数：发起攻击的单位，攻击范围，要攻击的阵营
    public static Collider2D AttackRangeCheck(Transform trans, float attackRange, string attackcamp)
    {
        Collider2D[] coll = Physics2D.OverlapCircleAll(trans.position, attackRange);

        foreach(Collider2D item in coll)
        {
            if(item.transform.tag == attackcamp)
            {
                return item;
            }
        }

        return null;
    }
}
