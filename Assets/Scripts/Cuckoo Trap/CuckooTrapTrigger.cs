using Unity.VisualScripting;
using UnityEngine;

public class CuckooTrapTrigger : MonoBehaviour
{
    [SerializeField] CuckooTrapPopOut springOfCuckoo;

    void OnTriggerEnter(Collider other)
    {
        if (springOfCuckoo != null && other.gameObject.tag == "NPC")
        {
            Debug.Log("Triggered");
            springOfCuckoo.enabled = true; // enable the pop-out script
        }
    } 
}