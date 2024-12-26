using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCommonBehavior : MonoBehaviour
{
    private Unit unit;
    private SerializedDictionary<AttributeType, float> Attributes;

    private Collider2D AttackTargetCollider;
    private Unit AttackTarget;
    private Vector3 AttackPos=new Vector3(9999,9999,9999);

    private float moveSpeed;
    private float attackPower;
    private float attackRange;

    private Animator animator;

    [SerializeField] private bool isCommonAttack = false;

    private float attackTime = 0;
    private void Start()
    {
        unit = GetComponent<Unit>();
        Attributes = GetComponent<Unit>().TotalAttributes;
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //获取单位属性
        moveSpeed = Attributes[AttributeType.MoveSpeed];
        attackPower = Attributes[AttributeType.AttackPower];
        attackRange = Attributes[AttributeType.AttackRange];

        //确定普攻/技能攻击 目标
        AttackTargetCollider = CharacterBehaviorTool.AttackRangeCheck(
        transform, 10000f, "Unit");
        if (AttackTargetCollider != null)
        {
            AttackPos = AttackTargetCollider.transform.position;
            AttackTarget = AttackTargetCollider.GetComponentInParent<Unit>();
        }
        else
        {
            Debug.Log($"{unit.Name}没有目标");
        }

        //Debug.Log(Vector3.Distance(transform.position, AttackPos));
        //判断是否在普攻范围内并攻击
        if (Vector3.Distance(transform.position, AttackPos) <= attackRange)
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
        transform.position = Vector3.MoveTowards(transform.position, AttackPos, Time.deltaTime * moveSpeed);
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
}
