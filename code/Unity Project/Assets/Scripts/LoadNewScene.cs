using UnityEngine;

// Script is added to button objects to change scene when clicked
public class LoadNewScene : MonoBehaviour {

    public string sceneName;

    public void loadNewScene()
    {
        GlobalController.Instance.ChangeScene(sceneName);
    }
}
