using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    public int LevelScene;

    public void LevelStart()
    {
        SceneManager.LoadScene(LevelScene);
    }
}
