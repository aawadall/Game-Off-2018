using UnityEngine;

// What happens when we click on a creature in the habitat. 
// We want to send the creature on a mission of the player's choosing. 
public class CreatureInteract : Interactable {

    // Triggered when the creature is clicked 
    public override void interact()
    {
        SceneController.Instance.AskYesNoQuestion("Do you want to send your " 
                                                    + GetComponent<CreatureController>().creatureName 
                                                    + " on a mission?");
    }
}
