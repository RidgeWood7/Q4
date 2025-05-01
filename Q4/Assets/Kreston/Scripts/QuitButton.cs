using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}