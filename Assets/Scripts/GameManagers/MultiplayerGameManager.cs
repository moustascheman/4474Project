using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MultiplayerGameManager : MonoBehaviour
{
    public GameObject tankPrefab;
    public List<Tank> players;
    public List<GameObject> spawnPoints;

    //PlayerPref string used to get value, should be set in main menu
    string NUMPLAYERSPREF = "Pref_Multi_Num_Players";
    public MultiplayerUIManager uiMan;

    public int currentPlayer = 0;
    public int playerLimit = 1;
    public bool Firing = false;
    public int numPlayers = 1;
    public int damagedMoneyAmount = 50;
    public int killedMoneyAmount = 100;

    private Rigidbody2D currentProjectile = null;

    public GameObject playerWinUI;

    //UI Elements

    //IMPORTANT: When you want to modify text use TMP versions rather than normal uGUI Text
    public TextMeshProUGUI playerNumberText;
    //public TextMeshProUGUI winText;

    public Button fireButton;



    // Start is called before the first frame update
    //Perform Game-start operations such as spawning players
    void Start()
    {
     //   int numPlayers = PlayerPrefs.GetInt(NUMPLAYERSPREF);
        players = new List<Tank>();
        for(int i = 0; i< numPlayers; i++)
        {
            GameObject playerTank = Instantiate(tankPrefab, spawnPoints[i].transform);
            Tank playerTankComponent = playerTank.GetComponent<Tank>();
            playerTankComponent.playerNumber = i+1;
            players.Add(playerTankComponent);
            playerTankComponent.SetActive(false);
            playerTankComponent.setPlayerNumber();
            TankMoney money = playerTank.GetComponent<TankMoney>();
            money.gm = this;
        }
        startTurn();

    }

    public void fire()
    {
        if (!Firing)
        {
            Firing = true;
            GameObject tankObject = players[currentPlayer].gameObject;
            TankFire fireObj = tankObject.GetComponent<TankFire>();
            float forceVal = uiMan.forceSlider.value;
            fireObj.launchForce = forceVal;
            currentProjectile = fireObj.Fire();
            Debug.Log("Tank " + currentPlayer + " has Fired");
            uiMan.UpdateAmmoButtons();
            fireGameFlowOperations();
            players[currentPlayer].SetActive(false);
        }
    }


    /*
     * Used to wait until projectile has resolved before continuing to next turn
     */
    public void fireGameFlowOperations()
    {
        StartCoroutine(fireOperationRoutine());
    }


    public IEnumerator fireOperationRoutine()
    {
        yield return new WaitForSeconds(1f);
        if(currentProjectile != null)
        {
            yield return new WaitUntil(() => currentProjectile == null);
        }
        yield return new WaitForSeconds(1f);
        endTurn();
        startTurn();
    }



    public void endTurn()
    {
        int initIndex = currentPlayer;
        Tank tmp = null;
        while (tmp == null)
        {
            currentPlayer++;
            if (currentPlayer >= numPlayers)
            {
                currentPlayer = 0;
            }

            tmp = players[currentPlayer];
            if (currentPlayer == initIndex)
            {
                Debug.Log("Either a win or Tie State");
                if (tmp==null)
                {
                    Debug.Log("Tied");
                    tieGame();
                }
                else
                {
                    Debug.Log("won");
                    winGame(currentPlayer);
                }
            }

        }

        Firing = false;
    }

    public void startTurn()
    {
        uiMan.UpdateAmmoButtons();
        uiMan.updateForceSlider();
        fireButton.gameObject.SetActive(true);
        fireButton.enabled = true;
        playerNumberText.text = "Player " + (currentPlayer + 1);
        //perform UI setup and turn startup operations
        players[currentPlayer].SetActive(true);
    }



    public Tank getCurrentPlayerTank()
    {
        return players[currentPlayer];
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }


    public void winGame(int playerIndex)
    {
        uiMan.winText.text = "Player " + (playerIndex + 1) + " is the winner";
        playerWinUI.SetActive(true);

    }

    public void playerDamaged()
    {
        TankMoney money = getCurrentPlayerTank().gameObject.GetComponent<TankMoney>();
        money.currentMoney += damagedMoneyAmount;
    }

    public void playerKilled()
    {
        TankMoney money = getCurrentPlayerTank().gameObject.GetComponent<TankMoney>();
        money.currentMoney += killedMoneyAmount;
    }

    public void tieGame()
    {
        uiMan.winText.text = "TIE";
        playerWinUI.SetActive(true);
    }

    public void retryLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void returnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }


    public int getPlayerNumber()
    {
        return currentPlayer;
    }

}
