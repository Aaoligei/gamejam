using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterBehaviorTool
{

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


    public static List<Collider2D> SurroundCheck(Transform trans, float range, string camp)
    {
        var allColliders = Physics2D.OverlapCircleAll(trans.position, range);
        List<Collider2D> targetColliders = new List<Collider2D>();

        foreach (var collider in allColliders)
        {
            if (collider.tag == camp)
            {
                targetColliders.Add(collider);
            }
        }

        return targetColliders;
    }

}
