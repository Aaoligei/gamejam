using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    public float speed = 10f; // 投射物的速度
    public Transform target; // 投射物的目标
    public Skill skill;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (target != null)
        {
            // 计算目标方向
            Vector2 direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y).normalized;
            // 设置投射物的初始速度
            rb.velocity = direction * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        List<Collider2D> targets = CharacterBehaviorTool.SurroundCheck(other.transform, skill.skillArea, "enemy");
        if (targets != null)
        {
            foreach (Collider2D target in targets)
            {
                Unit unit = target.GetComponentInParent<Unit>();
                if (unit != null)
                {
                    unit.TakeDamage(skill.damage, AttackType.Magic);
                    // 销毁投射物
                    Destroy(gameObject);
                }
            }
        }
        
    }
}