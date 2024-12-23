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
    private Vector3 AttackPos;

    private Collider2D TargetCollider;
    private Unit Target;
    private Vector3 TargetPos;

    private float moveSpeed;
    private float attackPower;
    private float attackRange;

    private Skill skill;

    [SerializeField]private bool isCommonAttack = false;

    private float attackTime = 0;
    private float skillTime = 0;
    private void Start()
    {
        unit = GetComponent<Unit>();
        Attributes = GetComponent<Unit>().TotalAttributes;
    }

    private void Update()
    {
        //获取单位属性
        moveSpeed = Attributes[AttributeType.MoveSpeed];
        attackPower = Attributes[AttributeType.AttackPower];
        attackRange = Attributes[AttributeType.AttackRange];
        skill = unit.skill;
        
        //确定普攻/技能攻击 目标
        AttackTargetCollider = CharacterBehaviorTool.AttackRangeCheck(
        transform, 10000f, "enemy");
        if( AttackTargetCollider != null)
        {
            AttackPos = AttackTargetCollider.transform.position;
            AttackTarget = AttackTargetCollider.GetComponentInParent<Unit>();
        }
        else
        {
            Debug.Log("没有目标");
        }

        //判断是否有技能
        if(skill != null)
        {
            skillTime += Time.deltaTime;
            if (skillTime >= skill.cooldown)
            {
                CheckTarget();    
                if (Vector3.Distance(transform.position, TargetPos) <= skill.skillRange)
                {
                    skillTime = 0;
                    //技能
                    skill.Excute();
                }
                else
                {
                    Move();
                }
            }
            //判断是否在普攻范围内并攻击
            else if (Vector3.Distance(transform.position, AttackPos) <= attackRange)
            {
                CommonAttack();
            }
            else
            {
                Move();
            }
        }
        //判断是否在普攻范围内并攻击
        else if (Vector3.Distance(transform.position, AttackPos) <= attackRange)
             {
                CommonAttack();
             }
        else
        {
            Move();
        }
    }

    //移动
    void Move()
    {
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * moveSpeed);
        skillTime += Time.deltaTime;
        attackTime += Time.deltaTime;
        Debug.Log("正在移动...");
    }

    //普攻
    void CommonAttack()
    {
        if (!isCommonAttack)
        {
            Debug.Log("普通攻击");
            isCommonAttack = true;//攻击后进入间隔
            AttackTarget.TakeDamage(attackPower, unit.damegeType);
        }
        else
        {
            attackTime += Time.deltaTime;
            if (attackTime > Attributes[AttributeType.AttackInterval])
            {
                isCommonAttack = false;
                attackTime = 0;
            }
        }
    }

    //判断目标是否为友方，并设置target相关
    void CheckTarget()
    {
        if (!skill.isAttack)
        {
            TargetCollider = CharacterBehaviorTool.AttackRangeCheck(transform, 10000f, "Unit");
            TargetPos = TargetCollider.transform.position;
            Target = TargetCollider.GetComponentInParent<Unit>();
        }
        else
        {
            TargetCollider = AttackTargetCollider;
            TargetPos = AttackPos;
            Target = AttackTarget;
        }
    }
}
