using UnityEngine;

public class ArrowDrag : MonoBehaviour {
    public float angleConstraint = 110f;

    void OnMouseDrag() {
        // Get angle
        Vector3 tankWorldPosition = Camera.main.WorldToScreenPoint(transform.parent.position);
        tankWorldPosition = Input.mousePosition - tankWorldPosition;
        float fAngle = Mathf.Atan2(-tankWorldPosition.x, tankWorldPosition.y) * Mathf.Rad2Deg;

        // Update rotation
        transform.parent.rotation = Quaternion.AngleAxis(Mathf.Clamp(fAngle, -angleConstraint, angleConstraint), Vector3.forward);
    }
}
