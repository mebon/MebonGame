using System.Collections;
using UnityEngine;
public class PauseGame : MonoBehaviour
{
    public GameObject pauseImage, resumeImage, quitGame;
    public static bool gameIsPaused;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            pauseGame();
        }
        void pauseGame()
        {
            if (gameIsPaused)
            {
                pauseImage.SetActive(true);
                resumeImage.SetActive(false);
                Time.timeScale = 0f;
                quitGame.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                pauseImage.SetActive(false);
                resumeImage.SetActive(true);
                Time.timeScale = 1f;
                quitGame.SetActive(false);
                StartCoroutine(delayactiv());
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        IEnumerator delayactiv()
        {
            yield return new WaitForSeconds(1);
            resumeImage.SetActive(false);

        }
    }
}
