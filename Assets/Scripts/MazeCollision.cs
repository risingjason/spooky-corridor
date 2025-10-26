using UnityEngine;

public class MazeCollision : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    public bool isHighlighted = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MousePointer")
        {
            gameObject.GetComponent<MeshRenderer>().material = highlightMaterial;
            isHighlighted = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MousePointer")
        {
            gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
            isHighlighted = false;
        }
    }

    void Update()
    {
        if (isHighlighted && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked on " + gameObject.name);
        }
    }
}
