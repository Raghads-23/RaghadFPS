using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float damage = 5f; // مقدار الضرر الذي تسببه الرصاصة

    void Start()
    {
        // تدمير الرصاصة بعد 3 ثوانٍ تلقائيًا إذا لم تصطدم بشيء
        Destroy(gameObject, 3f);
    }
}
