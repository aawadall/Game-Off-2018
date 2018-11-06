using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use this to push text above the sprite sorting layer
public class PushAboveSprites : MonoBehaviour {

    public string layerPushTo;

	// Use this for initialization
	void Start () {

        GetComponent<Renderer>().sortingLayerName = layerPushTo;
    }
}
