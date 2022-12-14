using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastScript : MonoBehaviour
{
    float speed = 1f;
    float RotAngleY = 5;
    float rotationAmount = 1f;
    float offset = -60f;
    float yRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //yRotation = Mathf.Sin(Time.deltaTime) * rotationAmount ;
        //Debug.Log(Mathf.Sin(speed*Time.deltaTime));
        //transform.localEulerAngles = new Vector3(0, Mathf.PingPong(Time.deltaTime * 60, 90));
        //float rY = Mathf.SmoothStep(0, RotAngleY, Mathf.PingPong(Time.deltaTime * speed, 1));

        //transform.Rotate(new Vector3(0f, yRotation, 0f));
        //transform.rotation = Quaternion.Euler(0, rY, 0);
    }
}
