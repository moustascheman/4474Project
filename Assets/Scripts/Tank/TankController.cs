using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Description: Basic Movement Script
*/
public class TankController : MonoBehaviour
{
    private string MoveInputAxis = "Horizontal";

    // rotation that occurs in angles per second holding down input
    public float rotationRate = 360;

    // units moved per second holding down move input
    public float moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveAxis = Input.GetAxis(MoveInputAxis);

        Move(moveAxis);

        //certain key function go here
    }

    private void Move(float input)
    {
        transform.Translate(Vector3.right * input * moveSpeed * Time.deltaTime);
    }
}

