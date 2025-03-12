using System.Collections.Generic;
using UnityEngine;

public class FireBall : Skill
{
    public GameObject fireBall;
    
    public FireBall()
    {
        skillData = Resources.Load<SkillData>("fireBall");
        if (skillData == null)
        {
            Debug.LogError("无法加载火球术技能数据！");
        }
        else
        {
            Debug.Log($"成功加载火球术技能数据：{skillData.Name}");
        }
    }

    public override void Excute()
    {
        base.Excute();
        Debug.Log($"尝试释放火球术，当前单位：{currentUnit.name}");
        Collider2D coll = CharacterBehaviorTool.AttackRangeCheck(currentUnit.transform, skillRange, "enemy");

        if (coll != null)
        {
            Debug.Log($"找到目标：{coll.name}，距离：{Vector3.Distance(currentUnit.transform.position, coll.transform.position)}");
            SkillManager.Instance.GenrateFireBall(coll, this);
        }
        else
        {
            Debug.Log("未找到目标！");
        }
    }
}