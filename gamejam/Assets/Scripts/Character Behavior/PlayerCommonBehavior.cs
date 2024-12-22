using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerCommonBehavior : MonoBehaviour
{
    private Unit unit;
    private SerializedDictionary<AttributeType, float> Attributes;

    private Collider2D AttackTargetCollider;

    private Unit AttackTarget;

    [SerializeField]private bool isCommonAttack = false;

    private float time;
    private void Start()
    {
        unit = GetComponent<Unit>();
        Attributes = GetComponent<Unit>().TotalAttributes;
    }

    private void Update()
    {
        

        //确定攻击目标
        AttackTargetCollider = CharacterBehaviorTool.AttackRangeCheck(
        transform, 10000f, "enemy");
        AttackTarget = AttackTargetCollider.GetComponentInParent<Unit>();

        //执行普通攻击
        if (Vector3.Distance(transform.position, AttackTargetCollider.transform.position) 
        <= Attributes[AttributeType.AttackRange])
        {
            if(!isCommonAttack)
            {
                isCommonAttack = true;//攻击后进入间隔
                AttackTarget.TakeDamage(Attributes[AttributeType.AttackPower], unit.damegeType);
            }
            else
            {
                time += Time.deltaTime;
                if(time > Attributes[AttributeType.AttackInterval])
                {
                    isCommonAttack = false;
                    time = 0;
                }
            }
        }

        //移动
        transform.position = Vector3.Lerp(transform.position, AttackTargetCollider.transform.position,
        Time.deltaTime * Attributes[AttributeType.MoveSpeed]);
    }

}
