using UnityEngine;

public class CPUInteract : Interactable {

    private Canvas CPUScreen;

	// Use this for initialization
	private void Start () {

        CPUScreen = GetComponentInChildren<Canvas>();
        CPUScreen.gameObject.SetActive(false);
	}

    // Load the CPU screen on click 
    public override void interact()
    {
        base.interact();
        PlayerController.Instance.frozen = true;
        CPUScreen.gameObject.SetActive(true);
        GetComponentInChildren<CPUScreenController>().BootUp();
    }

    // View text when hovering mous over the CPU 
    protected override void OnMouseEnter()
    {
        base.OnMouseEnter();
        SceneController.Instance.activateTextPanel("Click here to access your CPU.\r\n" +
                                                   "From here, you can view your e-mail and e-shopping pages.");
    }
    protected override void OnMouseExit()
    {
        base.OnMouseExit();
        SceneController.Instance.deactivateTextPanel();
    }
}
