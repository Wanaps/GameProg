using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlay : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("PlayGame");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
