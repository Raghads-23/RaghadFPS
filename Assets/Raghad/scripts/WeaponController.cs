using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;     // ضع الـ Prefab الخاص بالرصاصة هنا
    public Transform firePoint;         // نقطة إطلاق النار
    public float bulletSpeed = 20f;     // سرعة الرصاصة

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // زر الفأرة الأيسر
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * bulletSpeed;
    }
}
