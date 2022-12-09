using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleAnimationState : StateMachineBehaviour
{
    float timer;
    int isWalkingHash;
    int waypointIndexHash;
    List<Transform> waypoints = new List<Transform>();
    NavMeshAgent agent;
    Vector3 agentPosition;

    //-------------------------------
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        timer = 0;
        isWalkingHash = Animator.StringToHash("isWalking");
        waypointIndexHash = Animator.StringToHash("waypointIndex");

        Transform wayPointsObject = GameObject.FindGameObjectWithTag("WaypointsA").transform;
        foreach (Transform t in wayPointsObject)
        {
            waypoints.Add(t);
        }


        agent = animator.GetComponent<NavMeshAgent>();
        //agent.SetDestination(waypoints[animator.GetInteger(waypointIndexHash)].position);

        // get agents position
        agentPosition = agent.transform.position;

    }

    //-------------------------------
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //agent.SetDestination(waypoints[animator.GetInteger(waypointIndexHash)].position);

        
        // check if agents position has changed
        if (Vector3.Distance(agentPosition, waypoints[animator.GetInteger(waypointIndexHash)].position)>0.1f)
        {
            timer += Time.deltaTime;
            if (timer > 2)
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
