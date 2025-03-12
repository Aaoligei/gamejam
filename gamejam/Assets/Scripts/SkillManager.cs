using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;
    public GameObject fireballPrefab; // Ͷ����Ԥ���������

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void GenrateFireBall(Collider2D coll,Skill skill)
    {
        // 实例化投掷物并设置目标
        GameObject fireball = Instantiate(fireballPrefab, skill.currentUnit.transform.position, Quaternion.identity);
        FireballProjectile projectile = fireball.GetComponent<FireballProjectile>();
        projectile.target = coll.transform;
        projectile.skill = skill;  // 传递技能数据
        Debug.Log($"生成火球！伤害：{skill.damage}，范围：{skill.skillArea}");
    }
}
