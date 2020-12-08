using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class numPlayers : MonoBehaviour
{

    Text textComponent;

    void Start()
    {
        textComponent = GetComponent<Text>();
    }

    public void SetSliderValue(float sliderValue)
    {
        textComponent.text = Mathf.Round(sliderValue).ToString();
    }
}