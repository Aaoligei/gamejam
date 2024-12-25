using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterBehaviorTool
{
    //判读是否在攻击范围之类 参数：发起攻击的单位，攻击范围，要攻击的阵营
    public static Collider2D AttackRangeCheck(Transform trans, float attackRange, string attackcamp)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(trans.position, attackRange);

        if (colliders.Length > 0)
        {
            Collider2D closest = null;
            float closestDistance = float.MaxValue;

            foreach (var collider in colliders)
            {
                if(collider.tag == attackcamp)
                {
                    float distance = Vector3.Distance(trans.position, collider.transform.position);

                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closest = collider;
                    }
                }
            }

            if (closest != null)
            {
                return closest;
            }
            else
            {
                return null;
            }
        }
            return null;
    }
}
