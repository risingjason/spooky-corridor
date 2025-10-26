using System;
using UnityEngine;

public class TrapMaterialize : MonoBehaviour
{
    [SerializeField] GameObject[] allTraps;
    private UnityEngine.Object currentTrap;
    private int currentTrapIndex = 0;
    GameObject parent;

    void OnEnable()
    {
        parent = gameObject.transform.parent.gameObject;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && parent.GetComponent<MazeCollision>().isHighlighted)
        {
            if (currentTrap != null)
            {
                Destroy(currentTrap);
            }
            CycleTrap();
        }
    }

    public void CycleTrap()
    {
        currentTrapIndex = (currentTrapIndex + 1) % allTraps.Length;
        currentTrap = Instantiate(allTraps[currentTrapIndex], gameObject.transform.position, gameObject.transform.rotation);
    }
}
