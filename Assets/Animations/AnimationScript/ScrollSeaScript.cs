using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSeaScript : MonoBehaviour
{
    float scrollSpeedX = .004f;
    float scrollSpeedY = 0f;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rend);
        float offsetX = Mathf.Sin(Time.time * scrollSpeedX);
        float xClamp = Mathf.Clamp(offsetX, -0.04f, 0.04f);
        float offsetY = Mathf.Sin(Time.time * scrollSpeedY);
        rend.material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
    }
}
