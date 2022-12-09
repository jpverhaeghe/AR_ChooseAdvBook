using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleAnimationState : StateMachineBehaviour
{
    // local variables
    float timer;
    int isWalkingHash;
    int waypointIndexHash;
    Vector3 agentPosition;

    // reference
    List<Transform> waypoints = new List<Transform>();
    NavMeshAgent agent;


    //-------------------------------
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        timer = 0;
        isWalkingHash = Animator.StringToHash("isWalking");
        waypointIndexHash = Animator.StringToHash("waypointIndex");

        // get waypoints and add to list
        Transform wayPointsObject = GameObject.FindGameObjectWithTag("WaypointsA").transform;
        foreach (Transform t in wayPointsObject)
        {
            waypoints.Add(t);
        }

        // get nav mesh agent
        agent = animator.GetComponent<NavMeshAgent>();

        // get agents position
        agentPosition = agent.transform.position;

    }

    //-------------------------------
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // check if agents position has changed
        if (Vector3.Distance(agentPosition, waypoints[animator.GetInteger(waypointIndexHash)].position)>0.1f)
        {
            //Debug.Log("Move to walking");
            timer += Time.deltaTime;
            if (timer > 0.5)
            {
                animator.SetBool(isWalkingHash, true);
            }
        }
    }

    //-------------------------------
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
   
    }

}
