using UnityEngine;

public class FollowSpringTip : MonoBehaviour
{
    [SerializeField] private Transform springTransform; // assign Spring here
    [SerializeField] private Vector3 tipOffset; // will store local offset
    private Vector3 initialScale;

    void Start()
    {
        if (springTransform == null)
        {
            Debug.LogError("Spring Transform not assigned!");
            enabled = false;
            return;
        }

        // Store original scale
        initialScale = transform.localScale;

        // Calculate local-space offset relative to the spring
        tipOffset = springTransform.InverseTransformPoint(transform.position);
    }

    void LateUpdate()
    {
        // Tip moves along spring's Z scale
        Vector3 tipLocal = new Vector3(0f, -0.3f, springTransform.localScale.z);
        transform.position = springTransform.TransformPoint(tipLocal);

        // Keep original scale
        transform.localScale = initialScale;
    }
}