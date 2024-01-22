using System.Collections;
using System.Collections.Generic;
using Serpent;
using UnityEngine;
using UnityEngine.UI;

public class LoseMenu : MonoBehaviour
{
    public Text ScoreText;
    public Text HighScoreText;

    void Start()
    {
        ScoreText.text = "Score : " + Player.score.ToString();
        HighScoreText.text = "High Score : " + Player.highScore.ToString();
    }
}
