using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    public string Name;
    public GameObject currentUnit;//技能当前挂载单位
    public Unit target;//技能目标
    public float skillRange;//技能范围
    public bool isAttack;//技能类别
    public float cooldown;//技能冷却
    public float timer;//技能计时器
    
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

    //释放技能
    public virtual void Excute()
    {

    }
}
