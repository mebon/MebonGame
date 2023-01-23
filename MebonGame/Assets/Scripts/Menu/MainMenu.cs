using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainScreen");
    }
    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void OpenChapters()
    {
        SceneManager.LoadScene("Chapters");
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MebonGame");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
