using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    public int MaxValue = 100;//���Ѫ��
    [SerializeField]
    public int Value = 100;//��ǰѪ��

    [SerializeField]
    private RectTransform bottomBar;
    [SerializeField]
    private RectTransform topBar;

    private float fullWidth;
    private float targetWidth => Value * fullWidth / MaxValue;
    [SerializeField]
    public float barChangeSpeed = 10f;

    private Coroutine adjustBarWidthCoroutine;//�����ж�Ѫ���仯�Ƿ����ڽ���
    private void Start()
    {
        fullWidth = topBar.rect.width;
    }
    private void Update()
    {
        //������
        if(Input.GetMouseButtonDown(1))
        {
            Change(20);
        }
        if(Input.GetMouseButtonDown(0))
        {
            Change(-20);
        }
    }
    //�ı�Ѫ��
    public void Change(int amount)
    {
        Value = Mathf.Clamp(Value + amount, 0, MaxValue);

        //�ж�Ѫ���仯�Ƿ����ڽ���
        if(adjustBarWidthCoroutine != null)
        {
            StopCoroutine(adjustBarWidthCoroutine);
        }

        adjustBarWidthCoroutine = StartCoroutine(AdjustBarWidth(amount));
    }
    //Ѫ���仯Ч��ʵ��
    private IEnumerator AdjustBarWidth(int amount)
    {
        //�������ֿ�Ѫ�ͼ�Ѫʱ��Ĳ�ͬЧ��
        var suddenChangeBar = amount >= 0 ? bottomBar : topBar;//�仯�������
        var slowChangeBar = amount >= 0 ? topBar : bottomBar;//�仯��һ�����

        suddenChangeBar.SetWidth(targetWidth);
        while(Mathf.Abs(suddenChangeBar.rect.width - slowChangeBar.rect.width) > 1f)//�ı���һ�����
        {
            slowChangeBar.SetWidth(
                Mathf.Lerp(slowChangeBar.rect.width, targetWidth, Time.deltaTime * barChangeSpeed));
            yield return null;
        }
        slowChangeBar.SetWidth(targetWidth);
    }
}
