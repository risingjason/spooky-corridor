using UnityEngine;

public class TriggerTrap : MonoBehaviour
{
    [SerializeField] GameObject trap1;
    void ontriggerEnter(Collider other)
      {
        if(other.gameObject.tag == "Villager")
        {
            trap1.SetActive(true);
        }
    }
}
