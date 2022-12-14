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

        if ( (other.gameObject.CompareTag("Money") ) || (other.gameObject.CompareTag("Honey") ) || (other.gameObject.CompareTag("Ending") ) )
        {
            // set up the next UI to show what page and set the variable for the GameManager to play the correct anim sequence
            GameManager.ReaderChoices choice;
            
            if (other.gameObject.CompareTag("Money") )
            { 
                choice = GameManager.ReaderChoices.MONEY;
            }
            else if (other.gameObject.CompareTag("Honey") )
            {
                choice = GameManager.ReaderChoices.HONEY;
            }
            else
            {
                //Debug.Log("collided with ending: " + other.gameObject.tag);
                choice = GameManager.ReaderChoices.ENDING_1;
            }

            gameManagerScript.SetUIChoiceText(choice);

            // save the item for later use in the book
            // TODO: This is specific to the poem book we are making, make this system more generic (inventory based?)
            gameManagerScript.itemSelected = choice;

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