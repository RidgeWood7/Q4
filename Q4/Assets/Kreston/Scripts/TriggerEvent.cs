using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent onTriggerEnter;

    private void OnTriggerEnter(Collider collision)
    {
        onTriggerEnter.Invoke();   
    }

    /*public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }*/
}
