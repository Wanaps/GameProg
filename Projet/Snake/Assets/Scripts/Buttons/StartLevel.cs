using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Buttons
{
    public class StartLevel : MonoBehaviour
    {
        [FormerlySerializedAs("LevelScene")] public int levelScene;

        public void LevelStart()
        {
            SceneManager.LoadScene(levelScene);
        }
    }
}