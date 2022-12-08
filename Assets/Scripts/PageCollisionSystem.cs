using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageCollisionSystem : MonoBehaviour
{
    private GameManager gameManagerScript;

    public void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);

        if ( (other.gameObject.CompareTag("Money") ) || (other.gameObject.CompareTag("Honey") ) )
        {
            // set up the next UI to show what page and set the variable for the GameManager to play the correct anim sequence
            GameManager.ReaderChoices choice;
            
            if (other.gameObject.CompareTag("Money") )
            { 
                choice = GameManager.ReaderChoices.MONEY; 
            }
            else
            {
                choice = GameManager.ReaderChoices.HONEY;
            }

            gameManagerScript.SetUIChoiceText(choice);

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