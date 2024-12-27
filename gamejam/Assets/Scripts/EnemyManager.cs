using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    public List<GameObject> enemies;
    public GameObject boss;
    public float timer;
    public float bossTimer;
    public GameObject genPos;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        timer = 3.0f;
        bossTimer = 15.0f;
    }

    private void Update()
    {
        timer-=Time.deltaTime;
        bossTimer -= Time.deltaTime;
        if(timer < 0.0f)
        {
            timer = 3.0f;
            GenerateEnemy();
        }
        if(bossTimer < 0.0f)
        {
            bossTimer = 15.0f;
            GenerateBoss();
        }
    }

    private void GenerateBoss()
    {
        GameObject gameobj = Instantiate(boss, genPos.transform.position , Quaternion.identity, null);
        gameobj.SetActive(true);
    }

    private void GenerateEnemy()
    {
        int index = Random.Range(0, enemies.Count);
        float rand = Random.Range(-1f, 3f);
        GameObject gameobj = Instantiate(enemies[index], genPos.transform.position + new Vector3(0f, rand, 0f), Quaternion.identity, null);
        gameobj.SetActive(true);
    }
}
