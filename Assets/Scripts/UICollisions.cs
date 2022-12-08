using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.ShowUI();
            Destroy(gameObject);
        }
    }
}
