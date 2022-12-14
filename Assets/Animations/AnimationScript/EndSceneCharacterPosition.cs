using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneCharacterPosition : MonoBehaviour
{

    [SerializeField] GameObject cat;
    [SerializeField] Transform[] catPositions;
    [SerializeField] GameObject owl;
    [SerializeField] Transform[] owlPositions;

    GameManager gameManagerScript;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();

        int positionIndex = (int)gameManagerScript.itemSelected -1;


        cat.transform.position = catPositions[positionIndex].position;
        owl.transform.position = owlPositions[positionIndex].position;

        cat.transform.rotation = catPositions[positionIndex].rotation;
        owl.transform.rotation = owlPositions[positionIndex].rotation;
    }


}
