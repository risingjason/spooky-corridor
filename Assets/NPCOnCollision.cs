using UnityEngine;

public class NPCOnCollision : MonoBehaviour
{
    [Header("Assign your Game Over UI Panel here")]
    public GameObject gameOverScreen;

    private void Start()
    {
        // Make sure Game Over screen starts hidden
        if (gameOverScreen != null)
            gameOverScreen.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        // You can tag your NPCs with "NPC" in the Inspector
        if (collision.transform.root.CompareTag("NPC"))
        {
            Debug.Log("NPC collided — Game Over!");
            if (gameOverScreen != null)
            {
                gameOverScreen.SetActive(true);
                Time.timeScale = 0f;
            }

            else
            {
                Debug.LogWarning("Game Over Screen not assigned in the Inspector!");
            }
        }
    }

}
