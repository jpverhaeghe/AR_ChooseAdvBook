using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    float zPos = 0;
    CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //float zPos = 0;
         zPos += Time.deltaTime * .5f;
        transform.position = new Vector3(0, 0, zPos);
    }
}
