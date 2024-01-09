using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonQuit : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }
}
