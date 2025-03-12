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

    private Animator animator;

    public Skill skill;

    [SerializeField]private bool isCommonAttack = false;

    public GameObject fireball;

    private float attackTime = 0;
    private float skillTime = 0;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        unit = GetComponent<Unit>();
        Attributes = GetComponent<Unit>().TotalAttributes;
    }

    private void Update()
    {
        //获取单位属性
        moveSpeed = Attributes[AttributeType.MoveSpeed];
        attackPower = Attributes[AttributeType.AttackPower];
        attackRange = Attributes[AttributeType.AttackRange];
        skill = unit.Skill;
        
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
            Debug.Log($"{unit.Name}没有目标");
            return;
        }

        //技能逻辑
        skillTime += Time.deltaTime;
        if (skillTime >= skill.cooldown && skill != null && skill.skillData != null)
        {
            Debug.Log("技能冷却完成");
            float distanceToTarget = Vector3.Distance(transform.position, AttackPos);
            
            if (skill.skillRange == 0 || distanceToTarget <= skill.skillRange)
            {
                Debug.Log($"{unit.Name}释放技能: {skill.Name}");
                skillTime = 0;
                animator.SetBool("IsMove", false);
                animator.SetBool("IsAttack", false);
                animator.SetBool("IsSkill", true);
                
                // 使用类型转换确保调用正确的子类方法
                if (skill is FireBall fireBall)
                {
                    fireBall.Excute();
                }
                else if (skill is GroupTherapy groupTherapy)
                {
                    groupTherapy.Excute();
                }
                else if (skill is Rage rage)
                {
                    rage.Excute();
                }
                else if (skill is HeavyStrike heavyStrike)
                {
                    heavyStrike.Excute();
                }
                else
                {
                    Debug.Log("failed");
                    skill.Excute();
                }
            }
            else
            {
                Move();
            }
        }
        //普攻逻辑
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
        animator.SetBool("IsMove", true);
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsSkill", false);
        transform.position = Vector3.MoveTowards(transform.position, AttackPos, Time.deltaTime * moveSpeed);
        skillTime += Time.deltaTime;
        attackTime += Time.deltaTime;
        Debug.Log($"{unit.Name}正在移动...");
    }

    //普攻
    void CommonAttack()
    {
        if (!isCommonAttack)
        {
            Debug.Log($"{unit.Name}普通攻击");
            isCommonAttack = true;//攻击后进入间隔
            animator.SetBool("IsMove", false);
            animator.SetBool("IsAttack", true);
            animator.SetBool("IsSkill", false);
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
