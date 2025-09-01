using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnlyUpMeter : MonoBehaviour
{
    [Header("Script made by MaskedKitten! No credits needed :D")]
    public Transform GorillaPlayer;
    [Header("Meter")]
    public TextMeshPro TextMeter;
    public bool RoundUp = true;
    [HideInInspector] public float height = 0;
    [HideInInspector] public float roundedHeight = 0;
    [Header("Highscore")]
    public TextMeshPro TextHighscore;
    [HideInInspector] public float highScore = 0;

    public void Start()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 1);
        TextHighscore.text = "Highscore: " + highScore.ToString();
    }

    public void Update()
    {
        height = GorillaPlayer.position.y;
        roundedHeight = Mathf.Round(height);
        if (RoundUp)
        {
            TextMeter.text = "Height: " + (roundedHeight.ToString());
            if (roundedHeight > highScore)
            {
                highScore = roundedHeight;
                TextHighscore.text = "Highscore: " + (roundedHeight.ToString());
                PlayerPrefs.SetFloat("HighScore", roundedHeight);
            }
        }
        else
        {
            TextMeter.text = "Height: " + (height.ToString());
            if (height > highScore)
            {
                highScore = height;
                PlayerPrefs.SetFloat("HighScore", height);
                TextHighscore.text = "Highscore: " + (height.ToString());
            }
        }
    }
}
