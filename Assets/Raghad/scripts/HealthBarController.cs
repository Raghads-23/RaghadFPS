using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    public RectTransform healthBarRect; // رابط إلى الـ RectTransform
    private float originalWidth;

    void Start()
    {
        // تخزين العرض الأصلي عند البداية
        originalWidth = healthBarRect.sizeDelta.x;
    }

    public void UpdateHealthBar(float healthPercentage)
    {
        // تحديث العرض بناءً على النسبة المئوية
        healthBarRect.sizeDelta = new Vector2(originalWidth * healthPercentage, healthBarRect.sizeDelta.y);
    }
}
