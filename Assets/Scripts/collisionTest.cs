using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionTest : MonoBehaviour
{
    private GameObject nextPageUI;

    public void Start()
    {
        // need to get the UI object in the scene, then deactivate it (can't find inactive objects)
        nextPageUI = GameObject.Find("UI");
        nextPageUI.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Money"))
        {
            nextPageUI.SetActive(true);
            Debug.Log("collided");

        }
    }
}





//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CollderManager : MonoBehaviour {
//    private static ParticleSystem fireFront;
//    private static ParticleSystem fireBack;

    // Use this for initialization
    //
    // void Start ()     {
    // fireFront = GameObject.FindGameObjectWithTag("FireFrontA").GetComponent<ParticleSystem>();
    // fireBack = GameObject.FindGameObjectWithTag("FireBackA").GetComponent<ParticleSystem>();
    // }       void OnTriggerEnter(Collider other)
    //  {        if (other is BoxCollider)
    //  {           fireFront.Play(true);        }
    //  else if (other is CapsuleCollider)
    //  {           fireBack.Play(true);
    //  }     }       void OnTriggerExit(Collider other)
    //  {        if (fireFront.isPlaying == true)
    //  fireFront.Stop(true);
    //  if (fireBack.isPlaying == true)
    //  fireBack.Stop(true);     }  }