using UnityEngine;

public class Firewood : MonoBehaviour
{
    public int points = 1; // النقاط التي سيجمعها اللاعب عند لمس الحطب
    private GameManager gameManager; // مرجع لـ GameManager لاحتساب النقاط

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // تأكد من أن GameManager في المشهد
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // تأكد أن اللاعب هو من لمس الحطب
        {
            gameManager.AddPoints(points); // أضف النقاط
            //Destroy(gameObject); // دمر الحطب
        }
    }
}
