using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D theRB;
    public float movementSpeed;
    public Animator myAnimator;

    public static PlayerController instance; //using this to make sure only one player character loads up and exists.

    public string areaTransitionName;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    public bool canMove = true; 

    // Use this for initialization
    void Start () {
        if(instance == null)
        {
            instance = this;  //the instance value will be set to this player ONLY. 
        } else
        {
            if(instance != this)
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update () {

        if (canMove) {
            theRB.velocity = movementSpeed * new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        } else {
            theRB.velocity = Vector2.zero;
        }

        myAnimator.SetFloat ("MoveX", theRB.velocity.x);
        myAnimator.SetFloat ("MoveY", theRB.velocity.y);

        if (Input.GetAxisRaw ("Horizontal") == 1 || Input.GetAxisRaw ("Vertical") == 1 || Input.GetAxisRaw ("Vertical") == -1 || Input.GetAxisRaw ("Horizontal") == -1) {
            if (canMove) {
                myAnimator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                myAnimator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            }
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),
                                         Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);

    }

    public void setBounds(Vector3 botLeft, Vector3 topRight)
    {
        bottomLeftLimit = botLeft + new Vector3(.4f, 1f, 0f);
        topRightLimit = topRight + new Vector3(-.4f, -1f, 0f);
    }
    

}