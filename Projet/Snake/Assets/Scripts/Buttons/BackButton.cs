using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{

    public class BackButton : MonoBehaviour
    {
        public static int MainScene = 0;

        public void BackToMain()
        {
            SceneManager.LoadScene(MainScene);
        }
    }
}
