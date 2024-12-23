using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skills")]
public class SkillData : ScriptableObject
{
    public string Name;
    //public GameObject currentUnit;//技能当前挂载单位
    //public Unit target;//技能目标
    public float skillRange;//技能距离
    public float skillArea;//技能作用范围
    public bool isAttack;//技能类别
    public float cooldown;//技能冷却
    public float damage;//伤害
    public float areaAttenuation;//技能衰减比例
    public float skillMultiplier;//技能系数
    public AttackType damageType;//伤害类型
}
