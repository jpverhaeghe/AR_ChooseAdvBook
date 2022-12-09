using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class WalkingAnimationState : StateMachineBehaviour
{

    int isWalkingHash;
    List<Transform> waypoints = new List<Transform>();
    //List<Transform> waypointsB = new List<Transform>();

    NavMeshAgent agent;
    public int waypointIndex = 0;
    int waypointIndexHash;
    //public int waypointIndexB = 0;
    //public int route = 0;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //route = 0;

        isWalkingHash = Animator.StringToHash("isWalking");
        waypointIndexHash = Animator.StringToHash("waypointIndex");

        Transform wayPointsObject = GameObject.FindGameObjectWithTag("WaypointsA").transform;
        foreach(Transform t in wayPointsObject)
        {
            waypoints.Add(t);
        }

        

        //Transform wayPointsObjectB = GameObject.FindGameObjectWithTag("WaypointsB").transform;
        //foreach (Transform t in wayPointsObjectB)
        //{
        //    waypointsB.Add(t);
        //}

        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[animator.GetInteger(waypointIndexHash)].position);
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if (Input.GetKey("space"))
        //{
        //    route += 1;
        //}

        //if (route > 1)
        //{
        //    route = 0;
        //}

        //Debug.Log(route);

        //if (route == 0)
        //{

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                animator.SetBool(isWalkingHash, false);
                //waypointIndex += 1;
                //agent.SetDestination(waypoints[waypointIndexHash].position);

            }
        //}

        //if (route == 1)
        //{
        //    if (agent.remainingDistance <= agent.stoppingDistance)
        //    {
        //        animator.SetBool(isWalkingHash, false);
        //        waypointIndexB += 1;
        //        agent.SetDestination(waypointsB[waypointIndexB].position);

        //    }
        //}




        //if (waypointIndex > waypoints.Count)
        //{
        //    waypointIndex = 0;
        //}

        //if (waypointIndexB > waypointsB.Count)
        //{
        //    waypointIndexB = 0;
        //}
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

}
