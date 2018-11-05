using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    private Vector3 startPosition;
    private Vector3 destination;
    private bool moving;
    private GameObject currentSelection;
    public float speed;

    private void Awake()
    {
        startPosition = new Vector3(); // Used to ensure that movement speed is linear
        destination = new Vector3();
        moving = false;
    }

    // Update is called once per frame
    void Update () {

        // Getting player input 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // see if the ray has hit something
        if (Physics.Raycast(ray, out hit))
        { 
            // Whatever it hits, move there if we click 
            if( Input.GetButtonDown("Fire1") )
            {
                // See if we've clicked the ground (walkable layer)
                if (hit.collider.gameObject.layer == 10)
                {
                    moving = true;
                    // change destination and startPosition
                    startPosition = gameObject.transform.position;
                    destination = hit.point;
                }
            }
        }
    }

    // Where the player actually moves 
    private void FixedUpdate()
    {
        // We move the player a little bit along the line between their position and destination 
        float lambda = Time.deltaTime * speed;

        if ( Vector3.Distance(destination, gameObject.transform.position) <= Math.Sqrt( Math.Pow( 0.05, 2) + Math.Pow( 3*lambda , 2 ) ) )
            moving = false;

        if ( moving )
            // Normalize to ensure that we always move at the same speed
            gameObject.transform.position += lambda * Vector3.Normalize( destination - startPosition );

        // Set player position to 0 on the z
        gameObject.transform.position -= new Vector3(0, 0, gameObject.transform.position.z);
    }
}
