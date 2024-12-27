using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LuneManager : MonoBehaviour
{
    public static int luneNums;
    public int genPerSecond;
    public float timer;
    public static TextMeshProUGUI UINums;
    public TextMeshProUGUI textMeshProNums;
    public TextMeshProUGUI textMeshProSpeed;
    public static LuneManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        timer = 1.0f;
    }

    private void Start()
    {
        textMeshProSpeed.text=genPerSecond.ToString();
        UINums = textMeshProNums;
    }

    private void Update()
    {
        timer-= Time.deltaTime;
        if(timer < 0.0f)
        {
            luneNums += genPerSecond;
            timer = 1.0f;
            textMeshProNums.text=luneNums.ToString();
        }
    }

    public static void LuneDecrease(int cost)
    {
        LuneManager.luneNums -= cost;
        UINums.text = luneNums.ToString();
    }
}
