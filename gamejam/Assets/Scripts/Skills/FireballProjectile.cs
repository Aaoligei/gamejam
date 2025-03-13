using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    public float speed = 10f; // 投掷物速度
    public Transform target; // 投掷物目标
    public Skill skill;
    public GameObject explosionEffectPrefab; // 爆炸特效预制体

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();

        if (target != null)
        {
            // 计算目标方向
            Vector2 direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y).normalized;
            // 设置投掷物初始速度
            rb.velocity = direction * speed;
            Debug.Log($"火球发射！目标：{target.name}，速度：{speed}");
        }
        else
        {
            Debug.LogError("火球没有目标！");
        }

        if (skill == null)
        {
            Debug.LogError("火球没有技能数据！");
        }
        else
        {
            Debug.Log($"火球技能数据：伤害={skill.damage}，范围={skill.skillArea}，类型={skill.damageType}");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (skill == null)
        {
            Debug.LogError("火球触发时没有技能数据！");
            return;
        }

        // 检查碰撞对象是否为敌人
        Unit hitUnit = other.GetComponentInParent<Unit>();
        if (hitUnit != null && other.CompareTag("enemy"))
        {
            // 获取范围内的所有目标
            List<Collider2D> targets = CharacterBehaviorTool.SurroundCheck(transform, skill.skillArea, "enemy");
            if (targets != null && targets.Count > 0)
            {
                foreach (Collider2D target in targets)
                {
                    Unit unit = target.GetComponentInParent<Unit>();
                    if (unit != null)
                    {
                        float distance = Vector2.Distance(transform.position, target.transform.position);
                        float damageMultiplier = 1f - (distance / skill.skillArea * skill.areaAttenuation);
                        float finalDamage = skill.damage * Mathf.Max(damageMultiplier, 0.1f);
                        
                        Debug.Log($"火球击中目标：{unit.Name}，距离：{distance:F2}，伤害：{finalDamage:F2}");
                        unit.TakeDamage(finalDamage, AttackType.Magic);
                    }
                }
            }
            Destroy(gameObject);
            // 播放爆炸特效
            if (explosionEffectPrefab != null)
            {
                GameObject explosionEffect = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
                Destroy(explosionEffect, 0.5f); // 1秒后销毁特效
            }
        }
    }

}