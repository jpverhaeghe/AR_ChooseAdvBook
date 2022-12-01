using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimationState : StateMachineBehaviour
{
    float timer;
    int isWalkingHash;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        isWalkingHash = Animator.StringToHash("isWalking");
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            animator.SetBool(isWalkingHash, true);
        }
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
   
    }

}
