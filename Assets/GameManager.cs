using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private enum Scene
    {
        MainMenu = 0,
        Game = 1
    }

    public void LoadGame()
    {
        SceneManager.LoadScene((int)Scene.Game);
        Score.score = 0;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene((int)Scene.MainMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
