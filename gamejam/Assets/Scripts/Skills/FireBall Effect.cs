using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallEffect : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //我先删了，有bug
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //我先删了，有bug
    }
}
