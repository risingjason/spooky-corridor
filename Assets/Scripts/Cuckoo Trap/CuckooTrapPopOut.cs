using UnityEngine;

public class CuckooTrapPopOut : MonoBehaviour
{
    [SerializeField] private Vector3 scaleAmount = new Vector3(0f, 0f, 0.01f); // how much to scale along each axis
    [SerializeField] private float scaleSpeed = 3f;
    [SerializeField] private Vector3 pivotOffset = new Vector3(0f, 0f, -0.5f); 
    // pivotOffset: the distance from the object’s center to the fixed end (in local space)

    private Vector3 startScale;
    private Vector3 targetScale;
    private float time;

    void OnEnable()
    {
        startScale = transform.localScale;
        targetScale = startScale + scaleAmount;
        time = 0f;
    }

    void Update()
    {
        time += Time.deltaTime * scaleSpeed;
        float t = Mathf.Clamp01(time);

        // Compute new scale
        Vector3 newScale = Vector3.Lerp(startScale, targetScale, t);

        // Compute how much the scale changed this frame
        Vector3 scaleChange = newScale - transform.localScale;

        // Move the object to keep the pivot end fixed
        transform.position += transform.rotation * Vector3.Scale(pivotOffset, scaleChange);

        // Apply the new scale
        transform.localScale = newScale;
    }
}