using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health = 100f; // قيمة الصحة الأساسية

    // دالة لتقليل الصحة
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"Enemy Health: {health}");

        if (health <= 0)
        {
            Die();
        }
    }

    // دالة الموت عند انتهاء الصحة
    void Die()
    {
        Debug.Log("Enemy Died!");
        Destroy(gameObject);
    }
}
