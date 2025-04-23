using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 5f;

    Interactable currentInteractable;

    public void interact(InputAction.CallbackContext ctx)
    {
        CheckInteraction();
        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        //if colliders with anything within player reach
        if (Physics.Raycast(ray, out hit, playerReach))
        {
            if (hit.collider.CompareTag("Interactable")) //if looking at an interactable object
            {
                Interactable newInteractable = hit.collider.GetComponentInParent<Interactable>();

                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }
            }

            else //if not interactable
            {
                DisableCurrentInteractable();
            }
        }

        else //if not within reach
        {
            DisableCurrentInteractable();
        }
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        HUDController.instance.EnableInteractionText(currentInteractable.message);
    }

    void DisableCurrentInteractable()
    {
        HUDController.instance.DisableInteractionText();
        if (currentInteractable)
        {
            currentInteractable = null;
        }
    }
}
