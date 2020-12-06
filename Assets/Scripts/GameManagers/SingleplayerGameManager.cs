using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SingleplayerGameManager : MonoBehaviour
{
    public SingleplayerUIManager uiMan;

    //Level Creator needs to initialize these variables manually

    public GameObject PlayerPrefab;
    public GameObject Targetprefab;

    public Transform playerSpawn;


    public List<Transform> TargetSpawns;
    public List<GameObject> targets;

    
    public int NumTargets;

    public string levelID;

    //Thresholds that represent the minimum number of turns needed to get the appropriate amount of stars
    //anything lower than the two star threshold is 3 stars.
    public int noStarMinThreshold;
    public int oneStarMinThreshold;
    public int twoStarMinThreshold;


    public int startingLargeShellCount = 0;
    public int startingRailgunCount = 0;

    public int NumTurns = 0;
    private int remainingTargets;

    //UIElements
    public Button FireButton;
    public TextMeshProUGUI remainingTargetsText;
    public TextMeshProUGUI turnsText;
    public TextMeshProUGUI newRecordText;
    public GameObject WinPanel;



    private Rigidbody2D currentProjectile;
    public Tank player;


    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObj = Instantiate(PlayerPrefab, playerSpawn);
        player = playerObj.GetComponent<Tank>();

        for(int i=0; i < NumTargets; i++)
        {
            GameObject target = Instantiate(Targetprefab, TargetSpawns[i]);
            targets.Add(target);
        }
        TankAmmo ammo = player.GetComponent<TankAmmo>();
        ammo.largeShellAmmo = startingLargeShellCount;
        ammo.railgunAmmo = startingRailgunCount;
        remainingTargets = NumTargets;
        uiMan.UpdateAmmoButtons();
        startTurn();
    }

    public void startTurn()
    {
        FireButton.gameObject.SetActive(true);
        remainingTargetsText.text = "Targets Remaining: " + remainingTargets.ToString();
        turnsText.text = "Turns passed: " + NumTurns.ToString();
    }


    public void Fire()
    {
        TankFire fireObject = player.gameObject.GetComponent<TankFire>();
        float force = uiMan.forceSlider.value;
        fireObject.launchForce = force;
        currentProjectile = fireObject.Fire();
        uiMan.UpdateAmmoButtons();
        fireGameFlowOperations();
    }

    public void fireGameFlowOperations()
    {
        StartCoroutine(fireOperationRoutine());
    }


    public IEnumerator fireOperationRoutine()
    {
        yield return new WaitForSeconds(1f);
        if (currentProjectile != null)
        {
            yield return new WaitUntil(() => currentProjectile == null);
        }
        endTurn();
    }

    public void endTurn()
    {
        int count = 0;
        NumTurns++;
        foreach(GameObject tar in targets)
        {
            if(tar != null)
            {
                count++;
            }
        }
        if(count == 0)
        {
            //game Won
            WinGame();
        }
        else
        {
            startTurn();
        }
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
    }

    public void WinGame()
    {
        //Time.timeScale = 0f;
        FireButton.gameObject.SetActive(false);
        int numStars = calculateNumStars();
        WinPanel.SetActive(true);

        //update the visual for the number of stars


        //get the current record for the level
        string StarsKey = Constants.SPHighScorePrefix + levelID;
        int bestScore = PlayerPrefs.GetInt(StarsKey, -1);
        if(numStars > bestScore)
        {
            newRecordText.text = "New Record!";
            PlayerPrefs.SetInt(StarsKey, numStars);
        }

        
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


    public int calculateNumStars()
    {
        if(NumTurns >= noStarMinThreshold)
        {
            return 0;
        }
        else if(NumTurns < noStarMinThreshold && NumTurns >= oneStarMinThreshold)
        {
            return 1;
        }
        else if(NumTurns < oneStarMinThreshold && NumTurns >= twoStarMinThreshold)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }

}
