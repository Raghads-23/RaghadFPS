using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health = 100f; // قيمة الصحة الأساسية
    private float maxHealth;
    public HealthBarController healthBar; // رابط إلى HealthBarController



        private void Start()
            {
                maxHealth = health;
            }


    // دالة التعامل مع الاصطدام
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletController bullet = collision.gameObject.GetComponent<BulletController>();

            if (bullet != null)
            {
                TakeDamage(bullet.damage); // تقليل الصحة بناءً على الضرر الموجود في الرصاصة
                Destroy(collision.gameObject); // تدمير الرصاصة عند الاصطدام
            }
        }
    }

    // دالة لتقليل الصحة
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"Enemy Health: {health}");

        // تحديث الـ Health Bar
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(health / maxHealth);
        }
        
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
