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
    public float timer;//���ܼ�ʱ��
    public float damage;//�˺�
    public AttackType damageType = AttackType.Physic;//�˺�����

    public Skill(string _name,GameObject _go, Unit _target, float _skillRange, bool _isAttack, float _cooldown,float _damage)
    {
        Name = _name;
        currentUnit = _go;
        target=_target;
        skillRange = _skillRange;
        isAttack = _isAttack;
        cooldown = _cooldown;
        timer=cooldown;
        damage=_damage;
    }

    //�ͷż���
    public virtual void Excute()
    {

    }
}
