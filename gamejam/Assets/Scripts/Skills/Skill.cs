using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill
{

    public string Name;
    public GameObject currentUnit;//���ܵ�ǰ���ص�λ
    public Unit target;//����Ŀ��
    public float skillRange;//���ܾ���
    public float skillArea;//�������÷�Χ
    public bool isAttack;//�������
    public float cooldown;//������ȴ
    public float damage;//�˺�
    public float areaAttenuation;//����˥������
    public float skillMultiplier;//����ϵ��
    public AttackType damageType;//�˺�����

    public SkillData skillData;//


    public void InitSkill()
    {
        Name = skillData.Name;
        skillRange = skillData.skillRange;
        skillArea = skillData.skillArea;
        isAttack = skillData.isAttack;
        cooldown = skillData.cooldown;
        damage = skillData.damage;
        areaAttenuation = skillData.areaAttenuation;
        skillMultiplier = skillData.skillMultiplier;
        damageType = skillData.damageType;
    }

    //�ͷż���
    public virtual void Excute() {}
}
