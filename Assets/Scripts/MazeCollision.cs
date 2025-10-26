using UnityEngine;

public class MazeCollision : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "MousePointer")
        {
            gameObject.GetComponent<MeshRenderer>().material = highlightMaterial;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MousePointer")
        {
            gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
        }
    }

}
