using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlBoatAnimation : MonoBehaviour
{
    Animator animator;
    int animationIndex;

    float timer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animationIndex = 0;
        InvokeRepeating("SwitchAnimation", 2f, 3f);
    }

    private void OnStart()
    {

    }

    void SwitchAnimation()
    {
        animationIndex += 1;

        if (animationIndex > 4)
        {
            animationIndex = 0;
        }

        //Debug.Log("index: " + animationIndex);
    }



    // Update is called once per frame
    void Update()
    {
        Debug.Log("index: " + animationIndex);
        animator.SetInteger("AnimationSelect", animationIndex);
    }
}
