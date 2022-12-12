using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation.Samples;

public class GameManager : MonoBehaviour
{
    // Enumerated types
    public enum ReaderChoices
    {
        EMPTY,
        HONEY,
        MONEY,
        ENDING_1,
        ENDING_2,
    }

    public enum UI_Element
    {
        BOOK_INSTRUCTIONS,
        ITEM_INSTRUCTIONS,
        NEXT_PAGE,
    }

    // Serialized fields used by this script
    [Header("AR information")]
    [SerializeField] PrefabImagePairManager arImages;

    [Header("UI Elements to Use")]
    [SerializeField] GameObject[] UIElements;       // The UI elements to be used
    [SerializeField] TMP_Text infoText;             // The text for the info page UI that is displayed
    [SerializeField] Texture[] itemImages;          // The images (as textures) that can be displayed in the next page UI
    [SerializeField] RawImage choiceImage;          // The image to update in the next page UI
    [SerializeField] TMP_Text pageText;             // The text for the next page UI that is displayed

    // public variables used by other scripts
    public ReaderChoices itemSelected;

    // reference to player and animator
    //GameObject player;
    //Animator anim;

    // private variables
    private ReaderChoices readerChoice;             // The variable to keep track of the user choices during the book reading

    /// <summary>
    /// Start up systems for this object
    /// </summary>
    ///
    private void Awake()
    {

    }

    /// <summary>
    /// The start method to set up things for this script when the script is first loaded into the scene.
    /// </summary>
    private void Start()
    {
        // set the first choice to empty
        SetReaderChoice(ReaderChoices.EMPTY);

        // defaulting the item selected to Honey so if for some reason the item selection fails it won't crash.
        itemSelected = ReaderChoices.HONEY;

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
    /// Gets the current reader choice as an int
    /// </summary>
    /// <returns>the integer value of the current readers choice</returns>
    public int GetReaderChoice()
    {
        return (int)readerChoice;
    }

    /// <summary>
    /// Sets up the text based on the choice given and displays the correct textbox
    /// </summary>
    /// <param name="choice"></param>
    public void SetUIChoiceText(ReaderChoices choice)
    {
        // set the choice for this...perhaps this method is overkill...
        SetReaderChoice(choice);

        // access the player through tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Animator anim = player.GetComponent<Animator>();

        // set the animator parameter waypointIndex with readerChoice
        anim.SetInteger("waypointIndex", (int)readerChoice);

        //Debug.Log("animator index updated" + anim.GetInteger("waypointIndex"));
        //Debug.Log("Walking waypoint is: " + readerChoice);
        
    } // end SetUIChoiceText

    /// <summary>
    /// Removes all GameObjects currently instantiated in the AR world
    /// </summary>
    public void RemoveGameObjects()
    {
        // find and remove all AR components
        arImages.DestroyCurrentInstantiatedGameObjects();

    } // end RemoveComponents

    /// <summary>
    /// Shows the UI for the given value
    /// </summary>
    /// <param name="uiToShow">The enumerated value for the UI to show</param>
    public void ShowUI(UI_Element uiToShow)
    {
        // if the UI to show is the next page, make sure the text is updated
        if (uiToShow == UI_Element.NEXT_PAGE)
        {
            String textOutput = "";

            // change up the info text if the honey or money were used
            if ( (readerChoice == ReaderChoices.HONEY) || (readerChoice == ReaderChoices.MONEY) )
            {
                // set up the text
                textOutput = "You have chosen the ";
                textOutput += readerChoice.ToString().ToLower() + " to go with you!";
                infoText.text= textOutput;

                // change the image
                choiceImage.texture = itemImages[(int)readerChoice - 1];
            }

            // set up the next page text
            textOutput = "Turn to page ";
            textOutput += ((int)readerChoice + 1) + " to continue the adventure!";
            pageText.text = textOutput;
        }

        UIElements[(int)uiToShow].SetActive(true);

    } // end ShowUI
}
