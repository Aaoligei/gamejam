using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayCounter : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    public RectTransform sun;
    public Transform sunTrans;

    public float sunstartPosX;
    public float sunstartPosY;

    private int numberToShow = 1;
    public float timer = 0;

    private void Start()
    {   
        sunstartPosX = -32;
        sunstartPosY = 11.5f;
        sunTrans = sun.transform;
        UpdateUI();
    }

    private void FixedUpdate()
    {
        if(timer >= 120)
        {
            timer = 0;
            numberToShow++;
            uiText.text = numberToShow.ToString();
            sun.anchoredPosition = new Vector2(sunstartPosX, sunstartPosY);
        }
        timer += Time.fixedDeltaTime;
        sun.anchoredPosition = new Vector2(sunstartPosX + (timer / 2f), sunstartPosY);
    }
    private void UpdateUI()
    {
        if (uiText != null)
        {
            uiText.text = numberToShow.ToString();
        }
        sun.anchoredPosition = new Vector2(sunstartPosX, sunstartPosY);
    }
}
