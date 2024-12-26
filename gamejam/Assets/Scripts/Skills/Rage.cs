using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage : Skill
{
    private float originalAttackSpeed; // 原始攻击速度
    private float originalAttackPower; // 原始攻击力

    private Coroutine coroutine;

    public void StartSomeRoutine(IEnumerator routine)
    {
        coroutine = CoroutineManager.Instance.StartCoroutine(routine);
    }

    public void StopSomeRoutine()
    {
        CoroutineManager.Instance.StopCoroutine(coroutine);
    }

    public Rage()
    {
        skillData = Resources.Load<SkillData>("rage");
    }

    public override void Excute()
    {
        base.Excute();

        // 假设有一个单位组件可以获取和设置攻击力和攻击速度
        Unit unit = currentUnit.GetComponent<Unit>();

        // 保存原始的攻击力和攻击速度
        originalAttackPower = unit.TotalAttributes[AttributeType.AttackPower];
        originalAttackSpeed = unit.TotalAttributes[AttributeType.AttackInterval];

        // 提升50%的攻击力和攻击速度
        unit.TotalAttributes[AttributeType.AttackPower] = originalAttackPower * 1.5f;
        unit.TotalAttributes[AttributeType.AttackInterval] = originalAttackSpeed * 0.75f;

        // 设置一个计时器，10秒后恢复原始攻击力和攻击速度
        StartSomeRoutine(RevertStatsAfterDuration(10.0f));
    }

    private IEnumerator RevertStatsAfterDuration(float duration)
    {
        // 等待指定的时间
        yield return new WaitForSeconds(duration);
            Unit unit = currentUnit.GetComponent<Unit>();

            // 恢复原始的攻击力和攻击速度
            unit.TotalAttributes[AttributeType.AttackPower] = originalAttackPower;
            unit.TotalAttributes[AttributeType.AttackInterval] = originalAttackSpeed;
        
    }
}
