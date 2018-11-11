using UnityEngine;

// Each scene has its own child of SceneController. 
// This deals with scene-specific elements 
// e.g. LabSceneController hides the dialogue UI panel, whereas HabitatSceneController doesn't 

public class SceneController : MonoBehaviour {

    protected TMPro.TextMeshProUGUI UIText;
    public GameObject YesNoButtons;
    public GameObject textPanel;
    public bool frozen; // used to freeze panel
    public bool Frozen { get; set; }
    public float xBound;
    public float yBound;

    #region Singleton and set UIText
    public static SceneController Instance;

    public virtual void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        // UIText setting 
        UIText = textPanel.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        UIText.gameObject.SetActive(false);
        frozen = false;
    }
    #endregion

    // Activate and deactivate panel 
    public virtual void activateTextPanel( string textToAdd )
    {
        if (!frozen)
        {
            UIText.text = textToAdd;
            UIText.gameObject.SetActive(true);
            textPanel.SetActive(true);
        }
    }
    public virtual void deactivateTextPanel()
    {
        UIText.text = "";
        UIText.gameObject.SetActive(false);
    }

    // Cleans the text panel of all content
    public void wipeTextPanel()
    {
        UIText.text = "";
        YesNoButtons.SetActive(false);
        frozen = false;
    }

    // Used to ask the player a yes/no question 
    public void AskYesNoQuestion(string question)
    {
        UIText.text = question;
        YesNoButtons.SetActive(true);
        frozen = true;
    }
}
