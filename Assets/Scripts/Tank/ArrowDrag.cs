using UnityEngine;

public class ArrowDrag : MonoBehaviour {
    public float maxAngleConstraint = 110f;
    public float minAngleConstraint = -110f;

    void OnMouseDrag() {
        // Get angle
        Vector3 tankWorldPosition = Camera.main.WorldToScreenPoint(transform.parent.position);
        tankWorldPosition = Input.mousePosition - tankWorldPosition;
        float fAngle = Mathf.Atan2(tankWorldPosition.y, tankWorldPosition.x) * Mathf.Rad2Deg - 90;

        // Update rotation
        transform.parent.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(fAngle, minAngleConstraint, maxAngleConstraint));
    }
}
