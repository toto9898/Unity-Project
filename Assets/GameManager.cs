using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SceneAsset GameScene;
    public SceneAsset MainMenuScene;

    public void LoadGame()
    {
        SceneManager.LoadScene(GameScene.name);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenuScene.name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
