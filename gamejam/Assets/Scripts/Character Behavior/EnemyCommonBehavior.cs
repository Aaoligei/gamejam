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

    private Collider2D TargetCollider;
    private Unit Target;
    private Vector3 TargetPos;

    private float moveSpeed;
    private float attackPower;
    private float attackRange;

    [SerializeField] private bool isCommonAttack = false;

    private float attackTime = 0;
    private float skillTime = 0;

    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        unit = GetComponent<Unit>();
        Attributes = GetComponent<Unit>().TotalAttributes;
    }

    private void Update()
    {
        //��ȡ��λ����
        moveSpeed = Attributes[AttributeType.MoveSpeed];
        attackPower = Attributes[AttributeType.AttackPower];
        attackRange = Attributes[AttributeType.AttackRange];

        //ȷ���չ�/���ܹ��� Ŀ��
        AttackTargetCollider = CharacterBehaviorTool.AttackRangeCheck(
        transform, 10000f, "Unit");
        if (AttackTargetCollider != null)
        {
            AttackPos = AttackTargetCollider.transform.position;
            AttackTarget = AttackTargetCollider.GetComponentInParent<Unit>();
        }
        else
        {
            Debug.Log($"{unit.Name}û��Ŀ��");
        }

        //�ж��Ƿ����չ���Χ�ڲ�����
        if (Vector3.Distance(transform.position, AttackPos) <= attackRange)
        {
            CommonAttack();
        }
        else
        {
            Move();
        } 
    }

    //�ƶ�
    void Move()
    {
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsMove", true);
        transform.position = Vector3.MoveTowards(transform.position, TargetPos, Time.deltaTime * moveSpeed);
        skillTime += Time.deltaTime;
        attackTime += Time.deltaTime;
        Debug.Log($"{unit.Name}�����ƶ�...");
    }

    //�չ�
    void CommonAttack()
    {
        if (!isCommonAttack)
        {
            animator.SetBool("IsAttack", true);
            animator.SetBool("IsMove", false);
            Debug.Log($"{unit.Name}��ͨ����");
            isCommonAttack = true;//�����������
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
