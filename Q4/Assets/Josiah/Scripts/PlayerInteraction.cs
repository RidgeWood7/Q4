using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3f;

    Interactable currentInteractable;

    // Update is called once per frame
    void Update()
    {
        //CheckInteraction();
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            //currentInteractable.Interact();
        }
    }
}
