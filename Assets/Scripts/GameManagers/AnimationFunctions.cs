using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationFunctions : MonoBehaviour
{
    //public GameObject destroyedText;
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void EndPlayerDestroyedAnim()
    {
        gameObject.SetActive(false);
    }

}
