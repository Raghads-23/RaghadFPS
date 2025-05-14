using UnityEngine;
using System.Collections.Generic;

public class FirewoodCollector : MonoBehaviour
{
    public int requiredFirewoodCount = 5;            // عدد الحطب المطلوب
    private HashSet<GameObject> collectedFirewood = new HashSet<GameObject>();

    // دالة لتحديث عدد الحطب الملتقط
    public void CollectFirewood(GameObject firewood)
    {
        if (!collectedFirewood.Contains(firewood))
        {
            collectedFirewood.Add(firewood);
            Debug.Log($"تم جمع حطب. العدد الحالي: {collectedFirewood.Count}/{requiredFirewoodCount}");
        }
    }

    // دالة لإرجاع عدد الحطب الحالي
    public int GetFirewoodCount()
    {
        return collectedFirewood.Count;
    }
}
