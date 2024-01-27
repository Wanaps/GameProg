using System;
using System.Collections;
using System.Collections.Generic;
using Serpent;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Buttons
{
    public class LoseMenu : MonoBehaviour
    {
        [FormerlySerializedAs("ScoreText")] public Text scoreText;
        [FormerlySerializedAs("HighScoreText")] public Text highScoreText;

        void Start()
        {
            if (Player.Score > Player.HighScore)
            {
                Player.HighScore = Player.Score;
            }

            if (scoreText == null)
            {
                highScoreText.text = "High Score : " + Player.HighScore.ToString();
            }
            else
            {
                scoreText.text = "Score : " + Player.Score.ToString();
            }
        }
    }
}
