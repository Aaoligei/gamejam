using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayCounter : MonoBehaviour
{
    public TextMeshProUGUI uiText;

    private int numberToShow = 1;
    private float timer = 0;

    private void Start()
    {
        UpdateUI();
    }

    private void FixedUpdate()
    {
        if(timer >= 120)
        {
            timer = 0;
            numberToShow++;
            uiText.text = numberToShow.ToString();
        }
        timer += Time.fixedDeltaTime;
    }
    private void UpdateUI()
    {
        if (uiText != null)
        {
            uiText.text = numberToShow.ToString();
        }
    }
}
