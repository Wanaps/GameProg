using System.Collections;
using System.Collections.Generic;
using Serpent;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;

    void Update()
    {
        ScoreText.text = Player.score.ToString();
        if (Player.score > Player.highScore) {
            Player.highScore = Player.score;
            ScoreText.color = Color.red;
            ScoreText.color = new Color(ScoreText.color.r, ScoreText.color.g, ScoreText.color.b, 0.5f);
        } else {
        ScoreText.color = Color.black;
        ScoreText.color = new Color(ScoreText.color.r, ScoreText.color.g, ScoreText.color.b, 0.5f);
        }
    }
}