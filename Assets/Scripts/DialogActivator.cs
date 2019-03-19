using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{

    public string[] lines; //lines to be shown in dialog box
    private bool canActivate; //boolean used to check whether a player has entered the collider zone
    public bool isPerson = true; //check if the object is an npc or object


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if play is in collider zone and clicks LMB then show dialog. 
        if(canActivate && Input.GetButtonDown("Fire1") && !DialogManager.instance.dialogBox.activeInHierarchy) {
            DialogManager.instance.showDialog(lines, isPerson);
        }
    }

    //if player enters collider zone, then trigger canActivate to true
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            canActivate = true;
        }
    }

    //if player enters collider zone, then trigger canActivate to false
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            canActivate = false;
        }
    }
}
