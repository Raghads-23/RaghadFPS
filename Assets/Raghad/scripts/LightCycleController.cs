using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightCycleController : MonoBehaviour
{
    public List<Light> lights; // قائمة الأنوار
    public float lightDuration = 5f; // مدة تشغيل كل نور
    public List<GameObject> firewoodObjects; // قائمة الحطب

    private int currentIndex = 0;

    // لتعقب الأشياء الملتقطة
    private HashSet<GameObject> pickedUpFirewoods = new HashSet<GameObject>();

    void Start()
    {
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

    public void AddToPickedUpList(GameObject firewood)
    {
        if (!pickedUpFirewoods.Contains(firewood))
        {
            pickedUpFirewoods.Add(firewood);

            // تأكد أن الحطب يظل مفعلًا إذا كان ملتقطًا
            firewood.SetActive(true);
        }
    }

    IEnumerator CycleLights()
    {
        while (true)
        {
            // نطفي كل الأنوار
            foreach (Light light in lights)
            {
                if (light != null)
                    light.enabled = false;
            }

            // نطفي كل الحطب **ما عدا الملتقط**
            foreach (GameObject firewood in firewoodObjects)
            {
                if (firewood != null && !pickedUpFirewoods.Contains(firewood))
                {
                    firewood.SetActive(false);
                }
            }

            // نشغل النور الحالي ونظهر الحطب إذا لم يكن ملتقطًا
            Light currentLight = lights[currentIndex];
            if (currentLight != null)
            {
                currentLight.enabled = true;

                if (firewoodObjects.Count > currentIndex)
                {
                    GameObject firewood = firewoodObjects[currentIndex];

                    // إذا لم يكن ملتقطًا، نظهره
                    if (!pickedUpFirewoods.Contains(firewood))
                    {
                        firewood.SetActive(true);
                    }
                }
            }

            yield return new WaitForSeconds(lightDuration);
            currentIndex = (currentIndex + 1) % lights.Count;
        }
    }
}
