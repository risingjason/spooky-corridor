using UnityEngine;

public class MousePosition3D : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 50f, ~layerMask))
        {
            transform.position = raycastHit.point;
        }
    }
}
