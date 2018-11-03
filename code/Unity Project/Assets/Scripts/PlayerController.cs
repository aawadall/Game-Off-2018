using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    private Vector3 startPosition;
    private Vector3 destination;
    private bool moving;
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

        // See if we're pressing mouse key 
        if (Input.GetButtonDown("Fire1"))
        {
            // see if the ray has hit the floor 
            if (Physics.Raycast(ray, out hit))
            {
                moving = true;
                // change destination and startPosition
                startPosition = gameObject.transform.position;
                destination = hit.point;
            }
        }
    }

    // Where the player actually moves 
    private void FixedUpdate()
    {
        // We move the player a little bit along the line between their position and destination 
        float lambda = Time.deltaTime * speed;

        if ( Vector3.Distance(destination, gameObject.transform.position) <= lambda )
            moving = false;

        if ( moving )
            // Normalize to ensure that we always move at the same speed
            gameObject.transform.position += lambda * Vector3.Normalize( destination - startPosition ); 
    }
}
