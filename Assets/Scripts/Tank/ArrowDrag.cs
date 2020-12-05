using UnityEngine;

public class ArrowDrag : MonoBehaviour {
    public float maxAngleConstraint = 110f;
    public float minAngleConstraint = -110f;

    void OnMouseDrag() {
        // Get angle
        Vector3 tankWorldPosition = Camera.main.WorldToScreenPoint(transform.parent.position);
        tankWorldPosition = Input.mousePosition - tankWorldPosition;
        float fAngle = Mathf.Atan2(tankWorldPosition.y, tankWorldPosition.x) * Mathf.Rad2Deg;

        // Update rotation
        transform.parent.rotation = Quaternion.Euler(0, 0, fAngle - 90);
    }
}
