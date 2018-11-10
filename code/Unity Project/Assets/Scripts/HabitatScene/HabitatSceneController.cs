using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabitatSceneController : SceneController {

    // Add explanatory text for controls 
    public override void Awake()
    {
        base.Awake();

        UIText.text = "Use the arrow keys to move around.\r\nHighlight your creatures with the mouse to inspect them.";
        UIText.gameObject.SetActive(true);

        YesNoButtons.SetActive(false);
    }
}
