using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARFoundation.Samples;

public class GameManager : MonoBehaviour
{
    // Enumerated types
    public enum ReaderChoices
    {
        EMPTY,
        HONEY,
        MONEY,
    }

    // Serialized fields used by this script
    [Header("AR information")]
    [SerializeField] PrefabImagePairManager arImages;

    [Header("UI Elements to Use")]
    [SerializeField] GameObject nextPageUI;         // The UI to be used when reader makes choices
    [SerializeField] Text pageText;                 // The text for the page UI that is displayed

    // public variables used by other scripts

    // private variables
    private ReaderChoices readerChoice;             // The variable to keep track of the user choices during the book reading

    /// <summary>
    /// Start up systems for this object
    /// </summary>
    private void Start()
    {
        // set the first choice to empty so
        SetReaderChoice(ReaderChoices.EMPTY);

    } // end Start

    /// <summary>
    /// Updates this game object each frame
    /// </summary>
    private void Update()
    {

    } // end Update

    /// <summary>
    /// Sets the reader choice to incoming choice
    /// </summary>
    /// <param name="choice"></param>
    public void SetReaderChoice(ReaderChoices choice)
    {
        readerChoice = choice;

    } // end SetReaderChoice

    /// <summary>
    /// Sets up the text based on the choice given and displays the correct textbox
    /// </summary>
    /// <param name="choice"></param>
    public void SetUIChoiceText(ReaderChoices choice)
    {
        // set the choice for this...perhaps this method is overkill...
        SetReaderChoice(choice);

        String textOutput = "Turn to page ";
        textOutput += ( (int)readerChoice + 1) + " to continue the adventure!";
        pageText.text = textOutput;
        nextPageUI.SetActive(true);

        /* May not need the switch if we set it up correctly with the enum
        switch (readerChoice)
        {
            case ReaderChoices.HONEY:
                break;

            case ReaderChoices.MONEY:
                break;

            default:
                break;

        }
        */
    } // end SetUIChoiceText

    /// <summary>
    /// Removes all GameObjects currently instantiated in the AR world
    /// </summary>
    public void RemoveGameObjects()
    {
        // find and remove all AR components
        arImages.DestroyCurrentInstantiatedGameObjects();

    } // end RemoveComponents
}
