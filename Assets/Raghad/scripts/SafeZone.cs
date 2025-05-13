using UnityEngine;

public class SafeZone : MonoBehaviour
{
    private string inSafe = "You Entered The Safe Zone";
    private string outSafe = "You Left The Safe Zone";
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(inSafe);
            gameManager.UpdateSafeZoneText(inSafe);

            EnemyTarget target = other.GetComponent<EnemyTarget>();
            if (target != null && target.enemy != null)
                target.enemy.playerInSafeZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(outSafe);
            gameManager.UpdateSafeZoneText(outSafe);

            EnemyTarget target = other.GetComponent<EnemyTarget>();
            if (target != null && target.enemy != null)
                target.enemy.playerInSafeZone = false;
        }
    }
}
