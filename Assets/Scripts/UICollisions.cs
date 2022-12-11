using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICollisions : MonoBehaviour
{
    [SerializeField] GameManager.UI_Element uiToShow;

    /// <summary>
    /// When this game object gets triggered, it shows the next page UI and destroys itself
    /// </summary>
    /// <param name="other">The game object that collided with this trigger</param>
    private void OnTriggerEnter(Collider other)
    {
        // if it is the character object then it is time to show the UI to tell the reader what page to go to
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.ShowUI(uiToShow);
            Destroy(gameObject);
        }
    }
}
