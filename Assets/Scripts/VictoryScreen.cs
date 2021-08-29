using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class VictoryScreen : MonoBehaviour
{
    public TextMeshProUGUI thisScore;
    public TextMeshProUGUI highScore;

    private void Start()
    {
        int score = PlayerPrefs.GetInt("Score");
        int best = PlayerPrefs.GetInt("HighScore");

        thisScore.text = score.ToString();
        highScore.text = best.ToString();


    }
}
