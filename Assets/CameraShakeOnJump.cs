using UnityEngine;

public class CameraShakeOnJump : MonoBehaviour
{
    public Animator animator;
    private bool isShaking = false;

    private float dieShakeDuration = 0.3f;
    private float dieShakeTimer = 0f;

    private bool inDieState = false;

    void Update()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);

        // نحدد إذا إحنا داخل حالة die أو لا
        bool currentlyInDie = state.IsName("die");

        if (currentlyInDie && !inDieState)
        {
            // دخلنا حالة die الآن لأول مرة
            inDieState = true;
            isShaking = true;
            dieShakeTimer = dieShakeDuration;
            StartCoroutine(CameraShake.instance.Shake(dieShakeDuration, 0.1f));
        }
        else if (currentlyInDie && inDieState)
        {
            // إذا لا زلنا في die ونشغل العداد
            if (dieShakeTimer > 0)
            {
                dieShakeTimer -= Time.deltaTime;
            }
            else if (isShaking)
            {
                // انتهى الاهتزاز بعد 3 ثواني رغم استمرار الحالة
                isShaking = false;
            }
        }
        else
        {
            // خرجنا من حالة die، نسمح بتشغيل الاهتزاز مرة ثانية عند العودة
            inDieState = false;
            isShaking = false;

            // عالج حالة القفز بنفس الطريقة
            if (state.IsName("Jump") && !isShaking)
            {
                isShaking = true;
                StartCoroutine(CameraShake.instance.Shake(0.7f, 0.1f));
            }
        }
    }
}
