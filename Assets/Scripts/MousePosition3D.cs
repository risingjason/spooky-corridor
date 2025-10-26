using UnityEngine;

public class MousePosition3D : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;
    private float maxDistance = 50f;
    void FixedUpdate()
    {
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        transform.position = mouseWorldPosition;
    }

    Vector3 GetMouseWorldPosition()
    {
        Ray pointerRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(pointerRay, out RaycastHit raycastHit, maxDistance, ~layerMask))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
