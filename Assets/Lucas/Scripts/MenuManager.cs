using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// Loads the main menu
    /// </summary>
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Use this to quit the application
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Starts the game
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
