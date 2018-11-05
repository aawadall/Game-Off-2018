using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour {

    public string sceneName;

    public void loadNewScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
