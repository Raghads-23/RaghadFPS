using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health = 100f; // قيمة الصحة الأساسية
    private float maxHealth;
    public Animator animator; 
    public HealthBarController healthBar; // رابط إلى HealthBarController

    public AudioSource monsterScream;
    public AudioSource monsterDie;




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



    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        other.GetComponent<PlayerHealth>()?.PlayerTakeDamage(10f);
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
            Debug.Log("Damage");
            healthBar.UpdateHealthBar(health / maxHealth);
            monsterScream.Play();
            animator.SetTrigger("Damage");
        }
        
        if (health <= 0)
        {
        
            Die();
        }
    }

    // دالة الموت عند انتهاء الصحة
    void Die()
{
    Debug.Log("Die");
    animator.SetTrigger("Die");
    monsterDie.Play();
    StartCoroutine(WaitForAnimationToFinish());
}

private IEnumerator WaitForAnimationToFinish()
{
    AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

    // ننتظر لين يدخل فعلاً في حالة الموت
    while (!stateInfo.IsName("Die"))
    {
        yield return null;
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
    }

    // ننتظر لين ينتهي الأنيميشن
    yield return new WaitForSeconds(stateInfo.length);
    
    Destroy(gameObject);
}


}
