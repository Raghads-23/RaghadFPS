using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("Health Bar UI")]
    public Image healthBarImage; // ضع صورة الهيلث بار هنا في الـ Inspector

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void PlayerTakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // نتأكد أن القيمة لا تقل عن 0
        Debug.Log("Player Health: " + currentHealth);

        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");
        SceneManager.LoadScene("loseScene");
    }

    void UpdateHealthBar()
    {
        if (healthBarImage != null)
        {
            float fillAmount = currentHealth / maxHealth;
            healthBarImage.fillAmount = fillAmount;
        }
    }
}
