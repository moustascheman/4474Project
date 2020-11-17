using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject DraggedInstance;

    public Vector3 startPosition;
    public Vector3 mouseOffset;
    public float distanceToCamera;
    public GameObject pivot;
    public float maxAngleConstraint = 110f;
    public float minAngleConstraint = -110f;
    public float rotDistance = 0f;


    //Based on solution found at this link: https://answers.unity.com/questions/991083/dragging-a-2d-sprite-with-touch.html
    //needs to modified and expanded 

    //General Idea: Get Horizontal distance dragged and rotate pivot (sphere) by the appropriate amount.
    //There are complications due to changing directions (at 90 degrees, the rotation direction would become up/down) 

    public void OnBeginDrag(PointerEventData eventData)
    {
        DraggedInstance = gameObject;
        startPosition = transform.position;
        distanceToCamera = Mathf.Abs(startPosition.z - Camera.main.transform.position.z);

        mouseOffset = startPosition - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToCamera)
        );
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.touchCount > 1)
            return;

        //This gives a massive value for some reason. Perhaps it has to do with screen space and world space points
        rotDistance = Vector2.Distance((Vector2)startPosition, (Vector2)Input.mousePosition);


        transform.position = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToCamera)
            ) + mouseOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DraggedInstance = null;
        mouseOffset = Vector3.zero;
    }

}
