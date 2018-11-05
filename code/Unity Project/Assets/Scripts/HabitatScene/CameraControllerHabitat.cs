using System.Collections;
using System;
using UnityEngine;

public class CameraControllerHabitat : MonoBehaviour {

    public float xBound;
    public float yBound;
    public float cameraSpeed;

    private void FixedUpdate()
    {
        float deltaX = 0;
        float deltaY = 0;

        // Set the camera position on the x axis
        if ( Input.GetKey("right") && gameObject.transform.position.x > -xBound )
        {
            deltaX = -cameraSpeed;
        }
        else if ( Input.GetKey("left") && gameObject.transform.position.x < xBound )
        {
            deltaX = cameraSpeed;
        }

        // And on the y
        if ( Input.GetKey("up") && gameObject.transform.position.y < yBound )
        {
            deltaY = cameraSpeed;
        }
        else if ( Input.GetKey("down") && gameObject.transform.position.y > -yBound )
        {
            deltaY = -cameraSpeed;
        }

        // Now update camera position 
        gameObject.transform.position += new Vector3(deltaX, deltaY, 0f);
    }
}
