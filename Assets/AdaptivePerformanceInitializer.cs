using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class AdaptivePerformanceInitializer : MonoBehaviour
{
    void Start()
    {
        var ap = Holder.Instance;
        if (ap != null && ap.Active)
        {
            Debug.Log("Adaptive Performance is active and configured.");
        }
        else
        {
            Debug.LogError("Adaptive Performance is not configured properly.");
        }
    }
}
