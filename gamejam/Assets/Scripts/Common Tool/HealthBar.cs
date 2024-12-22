using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    public float MaxValue;//���Ѫ��
    [SerializeField]
    public float Value;//��ǰѪ��

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

    //�ı�Ѫ��
    public void Change(float amount)
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
    private IEnumerator AdjustBarWidth(float amount)
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
