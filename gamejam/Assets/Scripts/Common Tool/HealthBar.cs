using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    public int MaxValue = 100;//最大血量
    [SerializeField]
    public int Value = 100;//当前血量

    [SerializeField]
    private RectTransform bottomBar;
    [SerializeField]
    private RectTransform topBar;

    private float fullWidth;
    private float targetWidth => Value * fullWidth / MaxValue;
    [SerializeField]
    public float barChangeSpeed = 10f;

    private Coroutine adjustBarWidthCoroutine;//用于判断血条变化是否正在进行
    private void Start()
    {
        fullWidth = topBar.rect.width;
    }
    private void Update()
    {
        //测试用
        if(Input.GetMouseButtonDown(1))
        {
            Change(20);
        }
        if(Input.GetMouseButtonDown(0))
        {
            Change(-20);
        }
    }
    //改变血条
    public void Change(int amount)
    {
        Value = Mathf.Clamp(Value + amount, 0, MaxValue);

        //判断血条变化是否正在进行
        if(adjustBarWidthCoroutine != null)
        {
            StopCoroutine(adjustBarWidthCoroutine);
        }

        adjustBarWidthCoroutine = StartCoroutine(AdjustBarWidth(amount));
    }
    //血条变化效果实现
    private IEnumerator AdjustBarWidth(int amount)
    {
        //用于区分扣血和加血时候的不同效果
        var suddenChangeBar = amount >= 0 ? bottomBar : topBar;//变化更快的条
        var slowChangeBar = amount >= 0 ? topBar : bottomBar;//变化慢一点的条

        suddenChangeBar.SetWidth(targetWidth);
        while(Mathf.Abs(suddenChangeBar.rect.width - slowChangeBar.rect.width) > 1f)//改变慢一点的条
        {
            slowChangeBar.SetWidth(
                Mathf.Lerp(slowChangeBar.rect.width, targetWidth, Time.deltaTime * barChangeSpeed));
            yield return null;
        }
        slowChangeBar.SetWidth(targetWidth);
    }
}
