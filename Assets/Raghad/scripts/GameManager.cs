using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public TMP_Text scoreText; // score text

     public ParticleSystem fireParticle; // 🔥 
     public Light fireParticleLight; // 🔥 


    public TMP_Text zoneText;  // zone text

    private Coroutine hideZoneTextCoroutine;

    void Start()
    {
        UpdateScoreText();

         if (fireParticle != null)
        {
            fireParticle.Stop(); // نوقفه بالبداية
            fireParticleLight.enabled = false;
        }
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreText();

         if (score == 5 && fireParticle != null)
        {
            fireParticle.Play(); // ✅ شغل النار إذا وصل 5
            fireParticleLight.enabled = true;

        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = " " + score;
        }
    }

    public int GetScore()
{
    return score;
}


    public void UpdateSafeZoneText(string text)
    {
        if (zoneText != null)
        {
            zoneText.text = text;

            // نوقف الكوروتين السابق إذا كان شغال
            if (hideZoneTextCoroutine != null)
            {
                StopCoroutine(hideZoneTextCoroutine);
            }

            // نبدأ كوروتين جديد لإخفاء الرسالة بعد 3 ثواني
            hideZoneTextCoroutine = StartCoroutine(HideZoneTextAfterSeconds(3f));
        }
    }

    private IEnumerator HideZoneTextAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (zoneText != null)
        {
            zoneText.text = ""; // نخفي النص
        }
    }
}
