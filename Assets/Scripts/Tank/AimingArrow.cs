using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingArrow : MonoBehaviour
{

    public float minForceValue;
    public float maxForceValue;

    public float minAngleValue = -110;
    public float maxAngleValue = 110;
    public float angle = 0;


    private Vector3 playerScreenPoint;
    private Tank currentTank;
    private Transform tower; // <= sphere
    public MultiplayerGameManager gameManager;
    // Update is called once per frame
    void Update()
    {
        //get the current turn's tank
        currentTank = gameManager.getCurrentPlayerTank();

        //access the tower(sphere) of the tank
        tower = currentTank.transform.GetChild(1).gameObject.transform;

        // convert the coordinate of the player to the screen and then work out if the mouse is left or right of the player
        playerScreenPoint = Camera.main.WorldToScreenPoint(currentTank.transform.position);

        //rotate tank depending where mouse is relative to tank object
        if(Input.mousePosition.x <= playerScreenPoint.x) {
            //set the rotate to the tower(sphere) to face right
            tower.transform.eulerAngles  = new Vector3(tower.transform.eulerAngles.x, 180, tower.transform.eulerAngles.z);
        } else {
            //set the rotate to the tower(sphere) to face left
            tower.transform.eulerAngles = new Vector3(tower.transform.eulerAngles.x, 0, tower.transform.eulerAngles.z);
        }
    }
}
