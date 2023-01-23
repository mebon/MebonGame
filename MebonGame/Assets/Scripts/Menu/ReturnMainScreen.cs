using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnMainScreen : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainScreen");
        }
    }
}