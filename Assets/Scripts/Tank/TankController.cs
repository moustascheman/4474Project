using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Description: Basic Movement Script
*/
public class TankController : MonoBehaviour
{
    private string MoveInputAxis = "Horizontal";
    public AudioClip moveClip;
    AudioSource moveAudio;
    public GameObject tank;

    // units moved per second holding down move input
    public float moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        moveAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveAxis = Input.GetAxis(MoveInputAxis);

        //check for user input
        if (moveAxis != 0 ){
            //check if the tank has fuel
            if (tank.GetComponent<Tank>().currentFuel > 0){
                Move(moveAxis);
            }
            //certain key function go here
        }
        else {
            moveAudio.Stop();
        }

    }

    private void Move(float input)
    {
        transform.Translate(Vector3.right * input * moveSpeed * Time.deltaTime);
        tank.GetComponent<Tank>().decreaseFuel();
        //play tank moving noises
        if(!moveAudio.isPlaying){
            moveAudio.clip = moveClip;
            moveAudio.Play();
        }
    }
}

