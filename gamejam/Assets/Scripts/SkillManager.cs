using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;
    public GameObject fireballPrefab; // 投射物预制体的引用

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void GenrateFireBall(Collider2D coll,Skill skill)
    {
        // 实例化投射物并设置目标
        GameObject fireball = Instantiate(fireballPrefab, skill.currentUnit.transform.position, Quaternion.identity);
        FireballProjectile projectile = fireball.GetComponent<FireballProjectile>();
        projectile.target = coll.transform;
        Debug.Log("生成大火球！！！！！");
    }
}
