using UnityEngine;

public class SafeZone : MonoBehaviour
{

     private string inSafe = "You Entered The Safe Zone";
     private string outSafe = "You Left The Safe Zone";
    private GameManager gameManager; // مرجع لـ GameManager لاحتساب النقاط


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // تأكد من أن GameManager في المشهد
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           Debug.Log("You Entered The Safe Zone");
           gameManager.UpdateSafeZoneText(inSafe);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           Debug.Log("You Left The Safe Zone");
           gameManager.UpdateSafeZoneText(outSafe);
           
        }
    }
}
