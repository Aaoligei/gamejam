using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    public GameObject currentUnit;//���ܵ�ǰ���ص�λ
    public Unit target;//����Ŀ��
    public float skillRange;//���ܷ�Χ
    public bool isAttack;//�������
    public float cooldown;//������ȴ
    protected float timer;//���ܼ�ʱ��
    
    //�ͷż���
    public virtual void Excute()
    {

    }
}
