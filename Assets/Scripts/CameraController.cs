using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public Tilemap theMap;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    private float halfHeight;
    private float halfWidth; 


    // Start is called before the first frame update
    void Start()
    {
        if(PlayerController.instance != null)
        {
           target = PlayerController.instance.transform;
        } else
        {
            target = GameObject.FindWithTag("Player").transform;
        }


        halfHeight = Camera.main.orthographicSize; //gets the camera half size..
        halfWidth = halfHeight * Camera.main.aspect;

        //compresses the tilemap size to where only tiles are actually painted

        theMap.CompressBounds();

        //clip the bounds of the camera to the edges of the map. 
        bottomLeftLimit = theMap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f);
        topRightLimit = theMap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z); //make the camera follow the player

        //keep the camera inside the bounds. 
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),
                                         Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }
}
