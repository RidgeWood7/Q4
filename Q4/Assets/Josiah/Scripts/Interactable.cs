using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    //public string message;

    //public UnityEvent onInteraction;



    //// Update is called once per frame
    //void Update()
    //{

    //}

    //void CheckInteraction()
    //{
    //    RaycastHit hit;
    //    Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

    //    //if colliders with anything within player reach
    //    if (Physics.Raycast(ray, out hit, playerReach))
    //    {
    //        if (hit.collider.CompareTag("Interactable")) //if looking at an interactable object
    //        {
    //            Interactable newInteractable = hit.collider.GetComponent<Interactable>();

    //            if (newInteractable.enabled)
    //            {
    //                SetNewCurrentInteractable(newInteractable);
    //            }
    //        }

    //        else //if not interactable
    //        {
    //            DisableCurrentInteractable();
    //        }
    //    }

    //    else //if not within reach
    //    {
    //        DisableCurrentInteractable();
    //    }
    //}

    //public void Interact()
    //{
    //    onInteraction.Invoke();

    //}

    //void SetNewCurrentInteractable(Interactable newInteractable)
    //{
    //    currentInteractable = newInteractable;
    //}

    //void DisableCurrentInteractable()
    //{
    //    if (currentInteractable)
    //    {
    //        currentInteractable = null;
    //    }
    //}
}
