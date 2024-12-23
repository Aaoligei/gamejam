using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill
{
    public string Name;
    public GameObject currentUnit;//���ܵ�ǰ���ص�λ
    public Unit target;//����Ŀ��
    public float skillRange;//���ܷ�Χ
    public bool isAttack;//�������
    public float cooldown;//������ȴ
    public float damage;//�˺�
    public AttackType damageType;//�˺�����

    public Skill(string name, GameObject currentUnit, Unit target, float skillRange, bool isAttack, float cooldown, float damage, AttackType damageType)
    {
        Name = name;
        this.currentUnit = currentUnit;
        this.target = target;
        this.skillRange = skillRange;
        this.isAttack = isAttack;
        this.cooldown = cooldown;
        this.damage = damage;
        this.damageType = damageType;
    }



    //�ͷż���
    public virtual void Excute()
    {

    }
}
