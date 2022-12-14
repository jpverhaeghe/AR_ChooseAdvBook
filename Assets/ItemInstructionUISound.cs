using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstructionUISound : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip UIPopUpSound;


    // Start is called before the first frame update
    void Start()
    {
        Audio.PlayOneShot(UIPopUpSound);
        Debug.Log("sound played");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
