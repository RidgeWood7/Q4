using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public string message;

    public UnityEvent onInteraction;



    // Update is called once per frame
    void Update()
    {

    }

    public void Interact()
    {
        onInteraction.Invoke();
    }




}
