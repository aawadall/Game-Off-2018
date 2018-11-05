using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    protected TMPro.TextMeshProUGUI UIText;
    public GameObject textPanel;
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
    }
    #endregion

    // Activate and deactivate panel 
    public virtual void activateTextPanel( string textToAdd )
    {
        UIText.text = textToAdd;
        UIText.gameObject.SetActive(true);
        textPanel.SetActive(true);
    }
    public virtual void deactivateTextPanel()
    {
        UIText.text = "";
        UIText.gameObject.SetActive(false);
    }
}
