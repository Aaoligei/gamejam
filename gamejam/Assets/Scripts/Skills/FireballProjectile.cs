using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    public float speed = 10f; // 投掷物速度
    public Transform target; // 投掷物目标
    public Skill skill;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        List<Collider2D> targets = CharacterBehaviorTool.SurroundCheck(other.transform, skill.skillArea, "enemy");
        if (targets != null)
        {
            foreach (Collider2D target in targets)
            {
                Unit unit = target.GetComponentInParent<Unit>();
                if (unit != null)
                {
                    Debug.Log($"火球击中目标：{unit.Name}，造成{skill.damage}点伤害");
                    unit.TakeDamage(skill.damage, AttackType.Magic);
                    // 销毁投掷物
                    Destroy(gameObject);
                }
            }
        }
    }
}