using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    public string Name;
    public GameObject currentUnit;//���ܵ�ǰ���ص�λ
    public Unit target;//����Ŀ��
    public float skillRange;//���ܷ�Χ
    public bool isAttack;//�������
    public float cooldown;//������ȴ
    public float timer;//���ܼ�ʱ��
    
    public Skill(string _name,GameObject _go, Unit _target, float _skillRange, bool _isAttack, float _cooldown)
    {
        Name = _name;
        currentUnit = _go;
        target=_target;
        skillRange = _skillRange;
        isAttack = _isAttack;
        cooldown = _cooldown;
        timer=cooldown;
    }

    //�ͷż���
    public virtual void Excute()
    {

    }
}
