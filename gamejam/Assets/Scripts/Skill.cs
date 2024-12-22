using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    public GameObject currentUnit;//技能当前挂载单位
    public Unit target;//技能目标
    public float skillRange;//技能范围
    public bool isAttack;//技能类别
    public float cooldown;//技能冷却
    protected float timer;//技能计时器
    
    //释放技能
    public virtual void Excute()
    {

    }
}
