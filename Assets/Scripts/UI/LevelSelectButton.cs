using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour
{
    //levelId used to get rank info. Needs to be the same as the one inside the gameManager object for each level.
    public string levelId;
    //name of the scene. For simplification it may be easier to have sceneName be the levelId
    public string sceneName;

    private int rank;

    // Start is called before the first frame update
    void Start()
    {
        string starKey = Constants.SPHighScorePrefix + levelId;
        rank = PlayerPrefs.GetInt(starKey, 0);
        //set rank graphic to appropriate value
    }

    public void loadLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
