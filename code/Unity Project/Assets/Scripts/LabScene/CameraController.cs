using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public double zoom;
    public double maxZoom;
    public double minZoom;

    public Transform playerTransform;
    
    private void Start()
    {
        // Set initial zoom 
        zoom = 1;
    }

    // Move the camera in accordance with 'zoom'
    void LateUpdate () {
		
        // zoom the camera in and out with arrow keys
        if ( Input.GetKey( "up" ) && zoom <= maxZoom )
        {
            zoom += 0.01;
        }
        else if ( Input.GetKey("down") && zoom >= minZoom )
        {
            zoom -= 0.01;
        }

        // Ensure that the camera's position agrees with the player's 
        gameObject.transform.position = playerTransform.position + new Vector3(0f, 0f, (float) (1 / zoom) );

	}
}
