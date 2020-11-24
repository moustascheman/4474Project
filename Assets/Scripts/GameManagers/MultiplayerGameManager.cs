using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerGameManager : MonoBehaviour
{
    public GameObject tankPrefab;
    public List<Tank> players;
    public List<GameObject> spawnPoints;
    string NUMPLAYERSPREF = "Pref_Multi_Num_Players";
    public int currentPlayer = 0;
    public int playerLimit = 1;
    public bool Firing = false;


    //UI Elements

    public Button fireButton;



    // Start is called before the first frame update
    void Start()
    {
        int numPlayers = PlayerPrefs.GetInt(NUMPLAYERSPREF);
    /*    players = new List<Tank>();
        for(int i = 0; i< numPlayers; i++)
        {
            GameObject playerTank = Instantiate(tankPrefab);
            Tank playerTankComponent = playerTank.GetComponent<Tank>();
            playerTankComponent.playerNumber = i;
            players.Add(playerTankComponent);
            playerTankComponent.isActive = false;
        }*/
        startTurn();

    }

    public void fire()
    {
        if (!Firing)
        {
            Firing = true;
            GameObject tankObject = players[currentPlayer].gameObject;
            TankFire fireObj = tankObject.GetComponent<TankFire>();
            fireObj.Fire();
            Debug.Log("Tank " + currentPlayer + " has Fired");
            //Need to wait for a few seconds to make sure projectile has hit 
            //set wait time to expire time
            endTurn();
            startTurn();
        }
    }



    public void endTurn()
    {
        currentPlayer++;
        if(currentPlayer >= 1)
        {
            currentPlayer = 0;
        }
        Firing = false;
    }

    public void startTurn()
    {
        fireButton.enabled = true;
        //perfornm UI setup and turn startup operations
        //players[currentPlayer].isActive = true;
    }



    public int getPlayerNumber()
    {
        return currentPlayer;
    }

}
