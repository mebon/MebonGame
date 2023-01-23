using UnityEngine;
using UnityEngine.SceneManagement;
public class EndDoor : MonoBehaviour
{
    private bool isEndDoor;
    private void FixedUpdate()
    {
        if (isEndDoor)
        {
            if (Input.GetKey(KeyCode.E))
            {
                TheEnd();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndingDoor"))
        {
            isEndDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EndingDoor"))
        {
            isEndDoor = false;
        }
    }
    public void TheEnd()
    {
        SceneManager.LoadScene("EndGame");
        Cursor.lockState = CursorLockMode.None;
    }
}