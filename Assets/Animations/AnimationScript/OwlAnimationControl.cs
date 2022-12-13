using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlAnimationControl : MonoBehaviour
{
    Animator animator;

    float timer;
    bool standingUp;



    private void Awake()
    {
        timer = 0;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // on awake get the owl to stand from sitting to move into idle

        timer += Time.deltaTime;
        if (timer > 3f )
        {
            animator.SetBool("standingUp", true);
            standingUp = true;
        }

        if (standingUp)
        {
            animator.SetBool("isIdle", true);
        }

    }
}
