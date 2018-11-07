using UnityEngine.SceneManagement;
using UnityEngine;

public class HabitatInteract : Interactable {

    // Place the Habitat functions here 
    public override void interact()
    {
        GlobalController.Instance.ChangeScene("Habitat");
    }

    // Override onMouseEnter/Exit to output text to the UI 
    protected override void OnMouseEnter()
    {
        base.OnMouseEnter();

        SceneController.Instance.activateTextPanel( "Click here to view your creature habitat." );
    }
    protected override void OnMouseExit()
    {
        base.OnMouseExit();

        SceneController.Instance.deactivateTextPanel();
    }
}
