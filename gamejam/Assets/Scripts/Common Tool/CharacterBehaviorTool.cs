using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterBehaviorTool
{
    //�ж��Ƿ��ڹ�����Χ֮�� ���������𹥻��ĵ�λ��������Χ��Ҫ��������Ӫ
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
