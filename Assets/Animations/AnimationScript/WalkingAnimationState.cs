using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class WalkingAnimationState : StateMachineBehaviour
{
    // local variables
    int isWalkingHash;
    public int waypointIndex = 0;
    int waypointIndexHash;

    // references
    List<Transform> waypoints = new List<Transform>();
    NavMeshAgent agent;

    //--------------------------------
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        isWalkingHash = Animator.StringToHash("isWalking");
        waypointIndexHash = Animator.StringToHash("waypointIndex");

        // add waypoints vec3 to list
        Transform wayPointsObject = GameObject.FindGameObjectWithTag("WaypointsA").transform;
        foreach(Transform t in wayPointsObject)
        {
            waypoints.Add(t);
        }

        // get nav mesh agent and set destination
        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[animator.GetInteger(waypointIndexHash)].position);
    }

    //--------------------------------
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

            // check if agent has reached destination and return to idle
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                animator.SetBool(isWalkingHash, false);

            }

    }

    //--------------------------------
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // prevents the agent from sliding when destination reached
        agent.SetDestination(agent.transform.position);
    }

}
