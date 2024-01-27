using Serpent;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Map
{
    public class ScoreManager : MonoBehaviour
    {
        [FormerlySerializedAs("ScoreText")] public Text scoreText;

        void Update()
        {
            scoreText.text = Player.Score.ToString();
            if (Player.Score > Player.HighScore)
            {
                Player.HighScore = Player.Score;
                scoreText.color = Color.red;
                scoreText.color = new Color(scoreText.color.r, scoreText.color.g, scoreText.color.b, 0.5f);
            }
            else
            {
                scoreText.color = Color.black;
                scoreText.color = new Color(scoreText.color.r, scoreText.color.g, scoreText.color.b, 0.5f);
            }
        }
    }
}