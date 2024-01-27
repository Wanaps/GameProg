using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class StartGameButton : MonoBehaviour
    {
        public int gameStartScene;

        public void StartGame()
        {
            SceneManager.LoadScene(gameStartScene);
        }
    }
}
