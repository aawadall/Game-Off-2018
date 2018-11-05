using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabSceneController : SceneController {

    // Remove the canvas when it's not being used 
    public override void Awake()
    {
        base.Awake();

        textPanel.SetActive(false);
    }

    // Override to deactivate canvas when not in use 
    public override void deactivateTextPanel()
    {
        base.deactivateTextPanel();
        textPanel.SetActive(false);
    }
    public override void activateTextPanel(string textToAdd)
    {
        base.activateTextPanel(textToAdd);
        textPanel.SetActive(true);
    }
}
