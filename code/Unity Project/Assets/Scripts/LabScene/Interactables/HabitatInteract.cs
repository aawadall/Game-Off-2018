using UnityEngine.SceneManagement;
using UnityEngine;

public class HabitatInteract : Interactable {

    // Place the Habitat functions here 
    public override void interact()
    {
        SceneManager.LoadScene("Habitat");
    }

}
