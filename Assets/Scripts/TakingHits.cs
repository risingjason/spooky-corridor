using UnityEngine;

public class TakingHits : MonoBehaviour
{
    [SerializeField] int fearHitPoints = 3;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            fearHitPoints--;
            handleEnemyDeath();
        }
    }

    private void handleEnemyDeath()
    {
        if (fearHitPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
