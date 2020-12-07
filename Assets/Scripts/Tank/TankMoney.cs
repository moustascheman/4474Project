using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMoney : MonoBehaviour
{
    //I really don't like doing this
    public MultiplayerGameManager gm;


    public int currentMoney = 0;

    public void onPlayerDamaged()
    {
        if(gm.getCurrentPlayerTank().gameObject != gameObject)
        {
            gm.playerDamaged();
        }
    }

    public void onPlayerKilled()
    {
        if (gm.getCurrentPlayerTank().gameObject != gameObject)
        {
            gm.playerKilled();
        }
    }
}
