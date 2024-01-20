using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// DO NOT DELETE

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    // +1 score every 0.5s

    public void Update()
    {
        scoreText.text = "Score : " + Spawner.Score.ToString();
    }

}
