using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    private bool _paused;

    public void ClickPause()
    {
        if (_paused == false)
        {
            Pause();
        }
        else
        {
            Continue();
        }
    }

    public void Pause()
    {
        _paused = true;
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("PAUSED");
    }

    public void Continue()
    {
        _paused = false;
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("UNPAUSED");
    }
}
