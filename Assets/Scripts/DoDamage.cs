using UnityEngine;

public class DoDamage : MonoBehaviour
{
    int fear = 1;
    private void OnCollisionEnter(Collision other)
    {
        fear--;
        Debug.Log("You've been scared!" + fear);
    }
}
