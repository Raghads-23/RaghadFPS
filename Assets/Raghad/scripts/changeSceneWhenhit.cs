using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSceneWhenHit : MonoBehaviour
{
    public string sceneToLoad = "winScene"; // اسم المشهد الذي سيتم التحويل له
    private FirewoodCollector firewoodCollector;

    void Start()
    {
        firewoodCollector = FindObjectOfType<FirewoodCollector>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (firewoodCollector != null && firewoodCollector.GetFirewoodCount() == 5)
            {
                Debug.Log("✅ تم جمع كل الحطب، الانتقال إلى المشهد التالي!");
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.Log("❌ لم يتحقق الشرط: عدد الحطب أقل من 5");
            }
        }
    }
}
