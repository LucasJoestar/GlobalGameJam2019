using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// Loads the bad end of the game.
    /// </summary>
    public static void LoadBadEnd()
    {
        SceneManager.LoadScene(2);
    }

    public static void LoadGoodEnd()
    {
        SceneManager.LoadScene(3);
    }

    /// <summary>
    /// Loads the main menu.
    /// </summary>
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Use this to quit the application.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Starts the game.
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
