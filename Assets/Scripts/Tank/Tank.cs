using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Basic Tank Script that handles basic tank functions that can be unified between both modes
//Should be extended with inheritance for MP mode
public class Tank : MonoBehaviour
{

    //Projectiles should fire from this point

    public List<GameObject> Inventory;
    public GameObject firingPoint;

    // Update is called once per frame
    void Update()
    {
        
    }
}
