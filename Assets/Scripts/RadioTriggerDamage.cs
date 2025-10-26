using UnityEngine;
using System.Collections;
using System.Reflection;

public class RadioTrap : MonoBehaviour
{
    [Header("Trap Settings")]
    public string targetTag = "NPC";
    public int fearDamagePerTick = 1;
    public float tickInterval = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log($"[RadioTrap] {other.name} entered the trap zone.");
            TakingHits target = other.GetComponent<TakingHits>();
            if (target != null)
            {
                Debug.Log($"[RadioTrap] {other.name} has TakingHits component - starting damage over time.");
                StartCoroutine(ApplyFearDamage(target));
            }

            else
            {
                Debug.LogWarning($"[RadioTrap] {other.name} does not have a TakingHits component.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log($"[RadioTrap] {other.name} exited the trap zone.");
            StopAllCoroutines(); // stop damaging when enemy leaves
        }
    }

    private IEnumerator ApplyFearDamage(TakingHits target)
    {
        // Access the private fearHitPoints field using reflection
        FieldInfo fearField = typeof(TakingHits).GetField("fearHitPoints", BindingFlags.NonPublic | BindingFlags.Instance);
        MethodInfo deathMethod = typeof(TakingHits).GetMethod("handleEnemyDeath", BindingFlags.NonPublic | BindingFlags.Instance);

        while (target != null)
        {
            Debug.Log($"[RadioTrap] Applying {fearDamagePerTick} Fear Damage to {target.name}.");
            int currentFear = (int)fearField.GetValue(target);
            currentFear -= fearDamagePerTick;
            fearField.SetValue(target, currentFear);

            // Call the existing death method
            deathMethod.Invoke(target, null);

            Debug.Log($"{target.name} took {fearDamagePerTick} Fear Damage! Remaining: {currentFear}");

            yield return new WaitForSeconds(tickInterval);
        }
    }
}

