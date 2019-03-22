using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogManager : MonoBehaviour {
    public Text dialogText; //reference to dialog text within the dialog box
    public Text nameText; // reference to the name text within the name box
    public GameObject dialogBox; // reference to the dialog box when conversating with NPCs
    public GameObject nameBox; // reference to the name Box during dialog sequences. 

    public string[] dialogLines; //array of dialog text 

    public int currentLine; //current line of dialog text. 
    private bool justStarted; //check if a dialog sequence has just started, 


    public static DialogManager instance; 


    // Start is called before the first frame update
    void Start() {

        instance = this; 

    }

    // Update is called once per frame
    void Update() {
        if (dialogBox.activeInHierarchy) {  //is the dialog box active in current scene
            if (Input.GetButtonUp("Fire1")) { //when user clicks left mouse button

                if (!justStarted) { //check if dialog just started, if not do this block
                    currentLine++; // increase to the next line

                    if (currentLine >= dialogLines.Length) { //making sure we dont go out of bounds array
                        dialogBox.SetActive(false); // if we go over, take away the dialog box
                        GameManager.instance.dialogActive = false ; // and allow our player to regain movement

                    }
                    else {
                        checkIfName(); // check to see if the dialog line is actually a name
                        dialogText.text = dialogLines[currentLine]; //change the dialog text to the next one
                    }
                } else {
                    justStarted = false; //this is here to prevent the initial mouse click from jumping to the next dialog line. 
                }

            }
        }
    }

    /**
     *  show dialog activiates the dialog box on screen to show users text.
     *  it akes newLines array as input which is what the npc or objects will say in conversation
     *  isPerson checks whether the object you are talking to is an NPC or an object, depending
     *  on the outcome, a name box wil or will not be displayed on top of the dialog box. 
     * */
    public void showDialog(string[] newLines, bool isPerson) { 
        dialogLines = newLines; //diaolog lines are given new lines passed by character
        currentLine = 0; //sets the initial line at 0. 
        checkIfName(); //check if the name changes during conversation. 
        dialogText.text = dialogLines[currentLine]; //assign the dialog text to the currentLine
        dialogBox.SetActive(true); //set the dialog box as active. 
        justStarted = true;
        nameBox.SetActive(isPerson); //check if isPerson is t/f and set the name box accordingly. 


        GameManager.instance.dialogActive = true; //halt the player from moving while in chat. 

    }

    /**
     * check if the dialog current line is actually a name that beloings in the name box. 
     * */
    public void checkIfName() {
        if (dialogLines[currentLine].StartsWith("n-")) {
            nameText.text = dialogLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }

}
