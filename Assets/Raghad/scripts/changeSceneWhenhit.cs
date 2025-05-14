using UnityEngine;
using UnityEngine.SceneManagement; 

public class changeSceneWhenhit : MonoBehaviour
{
    public string sceneToLoad = "winScene"; 
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager != null && gameManager.GetScore() == 5)
            {
                Debug.Log("Player Hit");
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.Log("❌ لم يتحقق الشرط: النقاط أقل من 5");
            }
        }
    }
}
