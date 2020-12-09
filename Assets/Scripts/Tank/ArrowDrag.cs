using UnityEngine;

public class ArrowDrag : MonoBehaviour {
    public float maxAngleConstraint = 260f;
    public float minAngleConstraint = 100f;
    public float fAngle;

    void OnMouseDrag() {
        // Get angle
        Vector3 tankWorldPosition = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.parent.position);
        fAngle = Mathf.Atan2(-tankWorldPosition.x, tankWorldPosition.y) * Mathf.Rad2Deg;

        // Update rotation
        transform.parent.eulerAngles = new Vector3(0f, 0f, Mathf.Clamp(fAngle, minAngleConstraint, maxAngleConstraint));
    }
}
