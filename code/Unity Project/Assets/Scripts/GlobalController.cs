using UnityEngine.SceneManagement;
using UnityEngine;

// The GlobalController will be a singleton that persists between scenes. 
// We'll use it to store global data (such as the player's money, exp, etc.) 
// And we'll also store the global UI as a child of this GameObject. 

public class GlobalController : MonoBehaviour
{
    #region Global Variables 

    // Make sure to update UI whenever we change one of these values
    private int money;
    public int Money
    {
        get { return money; }

        set
        {
            UpdateUI();
            money = value;
        }
    }

    private int xp;
    public int Xp
    {
        get { return xp; }

        set
        {
            UpdateUI();
            xp = value;
        }
    }

    #endregion

    // UI Values also set here
    #region Singleton Implementation and Awake 

    public static GlobalController Instance;

    private void Awake()
    {
        // Singleton 
        DontDestroyOnLoad(gameObject);

        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        // UI Values set 
        Money = 500;
        sceneNameText.text = SceneManager.GetActiveScene().name;
        Xp = 0;
    }

    #endregion

    // References to UI children 
    public TMPro.TextMeshProUGUI moneyText;
    public TMPro.TextMeshProUGUI sceneNameText;
    public TMPro.TextMeshProUGUI xpText;

    // Update the UI (called whenever we add money/xp etc.)
    public void UpdateUI()
    {
        moneyText.text = "Money: $" + Money.ToString();
        xpText.text = "XP: " + Xp.ToString();
        return;
    }

    // Change the scene 
    public void ChangeScene( string newSceneName )
    {
        SceneManager.LoadScene( newSceneName );
        sceneNameText.text = newSceneName;
    }
}