using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D theRB;
    public float movementSpeed;
    public Animator myAnimator;

    public static PlayerController instance; //using this to make sure only one player character loads up and exists.

    public string areaTransitionName; 

    // Use this for initialization
    void Start () {
        if(instance == null)
        {
            instance = this;  //the instance value will be set to this player ONLY. 
        } else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update () {
        theRB.velocity = movementSpeed * new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
        myAnimator.SetFloat ("MoveX", theRB.velocity.x);
        myAnimator.SetFloat ("MoveY", theRB.velocity.y);

        if (Input.GetAxisRaw ("Horizontal") == 1 || Input.GetAxisRaw ("Vertical") == 1 || Input.GetAxisRaw ("Vertical") == -1 || Input.GetAxisRaw ("Horizontal") == -1) {
            myAnimator.SetFloat ("lastMoveX", Input.GetAxisRaw ("Horizontal"));
            myAnimator.SetFloat ("lastMoveY", Input.GetAxisRaw ("Vertical"));
        }
    }
}