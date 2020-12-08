using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MPButton : MonoBehaviour
{
    public Slider numPlayersSlider;
    public string levelId;


    public void loadLevel()
    {
        int numPlayers = (int)numPlayersSlider.value;
        PlayerPrefs.SetInt(Constants.NUMPLAYERSPREF, numPlayers);
        SceneManager.LoadScene(levelId);
    }
}
