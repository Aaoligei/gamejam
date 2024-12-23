using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skills")]
public class SkillData : ScriptableObject
{
    public string Name;
    //public GameObject currentUnit;//���ܵ�ǰ���ص�λ
    //public Unit target;//����Ŀ��
    public float skillRange;//���ܾ���
    public float skillArea;//�������÷�Χ
    public bool isAttack;//�������
    public float cooldown;//������ȴ
    public float damage;//�˺�
    public float areaAttenuation;//����˥������
    public float skillMultiplier;//����ϵ��
    public AttackType damageType;//�˺�����
}
