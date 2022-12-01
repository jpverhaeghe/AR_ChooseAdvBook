using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;

public class NavBaker : MonoBehaviour
{

    [SerializeField]
    NavMeshSurface[] navMeshSurface;

    private void Start()
    {
        for (int i = 0; i < navMeshSurface.Length; i++)
        {
            navMeshSurface[i].BuildNavMesh();
        }
    }

}
