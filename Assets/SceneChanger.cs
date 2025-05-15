using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Set the name of the scene you want to load
    public string sceneName = "GameScene";

    // This method can be called from a UI Button
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
