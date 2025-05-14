using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;               // النص اللي يعرض الوقت
    public float startTimeInSeconds = 60f;  // الوقت الابتدائي بالثواني

    private float currentTime;
    private bool isRunning = true;

    private void Start()
    {
        currentTime = startTimeInSeconds;
    }

    private void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;
        currentTime = Mathf.Max(currentTime, 0f); // تأكد أنه ما يصير أقل من 0

        // تحويل الوقت إلى صيغة دقيقة:ثانية
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (currentTime <= 0f)
        {
            isRunning = false;
            SceneManager.LoadScene("loseScene");
        }
    }
}
