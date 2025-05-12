using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightCycleController : MonoBehaviour
{
    public List<Light> lights; // قائمة الأنوار
    public float lightDuration = 5f; // مدة تشغيل كل نور
    public List<GameObject> firewoodObjects; // قائمة الحطب

    private int currentIndex = 0;

    void Start()
    {
        // نطفي كل الأنوار والحطب في البداية
        foreach (Light light in lights)
        {
            if (light != null)
                light.enabled = false;
        }

        foreach (GameObject firewood in firewoodObjects)
        {
            if (firewood != null)
                firewood.SetActive(false); // إخفاء الحطب
        }

        StartCoroutine(CycleLights());
    }

    IEnumerator CycleLights()
    {
        while (true)
        {
            // نطفي كل الأنوار للتأكد
            foreach (Light light in lights)
            {
                if (light != null)
                    light.enabled = false;
            }

            // نطفي كل الحطب
            foreach (GameObject firewood in firewoodObjects)
            {
                if (firewood != null)
                    firewood.SetActive(false); // إخفاء الحطب
            }

            // نشغل النور الحالي
            Light currentLight = lights[currentIndex];
            if (currentLight != null)
            {
                currentLight.enabled = true;
                
                // عند تشغيل النور، نظهر الحطب المقابل له
                if (firewoodObjects.Count > currentIndex)
                {
                    firewoodObjects[currentIndex].SetActive(true); // إظهار الحطب
                }
            }

            yield return new WaitForSeconds(lightDuration);

            // نروح للنور اللي بعده
            currentIndex = (currentIndex + 1) % lights.Count;
        }
    }
}
