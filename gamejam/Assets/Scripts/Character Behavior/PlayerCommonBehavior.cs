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

    private float moveSpeed;
    private float attackPower;
    private float attackRange;

    private Skill skillModule;

    [SerializeField]private bool isCommonAttack = false;

    private float time;
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
        skillModule = unit.SkillModule;
        
        //确定普攻/技能攻击 目标
        AttackTargetCollider = CharacterBehaviorTool.AttackRangeCheck(
        transform, 10000f, "enemy");
        AttackPos = AttackTargetCollider.transform.position;
        AttackTarget = AttackTargetCollider.GetComponentInParent<Unit>();

        //判断技能是否可以发动
        if(skillModule.cooldown <= 0)
        {

        }

        //判断是否在普攻范围内并攻击
        if (Vector3.Distance(transform.position, AttackPos) <= attackRange)
        {
            if(!isCommonAttack)
            {
                Debug.Log("普通攻击");
                isCommonAttack = true;//攻击后进入间隔
                AttackTarget.TakeDamage(attackPower, unit.damegeType);
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
        else
        {
            //移动
            transform.position = Vector3.Lerp(transform.position, AttackPos, Time.deltaTime * moveSpeed);
        }
    }
}
