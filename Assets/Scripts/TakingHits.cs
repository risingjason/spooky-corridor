using UnityEngine;

public class TakingHits : MonoBehaviour
{
    [SerializeField] int fearHitPoints = 3;
    [SerializeField] RectTransform fearMeterForeGround; // assign in Inspector

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            // Read current width
            float currentWidth = fearMeterForeGround.sizeDelta.x;
            Debug.Log("Current width: " + currentWidth);

            // Increment width (example: increase by 10)
            Vector2 size = fearMeterForeGround.sizeDelta;
            size.x += 100/3f;
            fearMeterForeGround.sizeDelta = size;
            Debug.Log("new numbers for: " + size);
            handleEnemyDeath(size);
        }
    }

    private void handleEnemyDeath(Vector2 size)
    {
        if (size.x >= 100)
        {
            Destroy(this.gameObject);
        }
    }
}