using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour
{
    //levelId used to get rank info. Needs to be the same as the one inside the gameManager object for each level.
    public string levelId;
    //name of the scene. For simplification it may be easier to have sceneName be the levelId
    public string sceneName;

    public GameObject[] fullStars;
    public GameObject[] emptyStars;


    private int rank;

    // Start is called before the first frame update
    void Start()
    {
        string starKey = Constants.SPHighScorePrefix + levelId;
        rank = PlayerPrefs.GetInt(starKey, 0);
        //set rank graphic to appropriate value
        if(rank <= 0)
        {
            setNoStarsRank();
        }
        else if(rank == 1)
        {
            setOneStarRank();
        }
        else if(rank == 2)
        {
            setTwoStarRank();
        }
        //By Default three stars
        
    }

    public void loadLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    private void setNoStarsRank()
    {
        foreach(GameObject star in fullStars)
        {
            star.SetActive(false);
        }
        foreach(GameObject emptStar in emptyStars)
        {
            emptStar.SetActive(true);
        }
    }

    private void setOneStarRank()
    {
        fullStars[1].SetActive(false);
        fullStars[2].SetActive(false);
        emptyStars[1].SetActive(true);
        emptyStars[2].SetActive(true);
    }
    private void setTwoStarRank()
    {
        fullStars[2].SetActive(false);
        emptyStars[2].SetActive(true);
    }
}
