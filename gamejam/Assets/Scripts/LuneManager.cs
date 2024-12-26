using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LuneManager : MonoBehaviour
{
    public int luneNums;
    public int genPerSecond;
    public float timer;
    public TextMeshProUGUI textMeshPro;
    public static LuneManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        timer = 1.0f;
    }

    private void Update()
    {
        timer-= Time.deltaTime;
        if(timer < 0.0f)
        {
            luneNums += genPerSecond;
            timer = 1.0f;
            textMeshPro.text="×ÜÊýÁ¿"+luneNums.ToString();
        }
    }

    public void LuneDecrease(int cost)
    {
        luneNums -= cost;
    }
}
