using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public static int MainScene = 1;

    public void BackToMain()
    {
        SceneManager.LoadScene(MainScene);
    }
}
