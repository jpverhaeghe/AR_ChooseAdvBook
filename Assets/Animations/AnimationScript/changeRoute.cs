using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeRoute : MonoBehaviour
{
    [SerializeField] int route;
    public void routeA()
    {
        route = 0;
    }


    public void routeB()
    {
        route = 1;
    }

}
