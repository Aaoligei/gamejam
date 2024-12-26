using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{
    private static CoroutineManager _instance;

    public static CoroutineManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var obj = new GameObject("CoroutineManager");
                _instance = obj.AddComponent<CoroutineManager>();
            }
            return _instance;
        }
    }

    public Coroutine StartMyCoroutine(IEnumerator routine)
    {
        return StartCoroutine(routine);
    }

    public void StopMyCoroutine(Coroutine routine)
    {
        StopCoroutine(routine);
    }
}
