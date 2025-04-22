using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialTrigger : MonoBehaviour
{
    public UnityEvent OnPlayerEnterTrigger;
    public UnityEvent OnPlayerExitTrigger;

    private void OnTriggerEnter(Collider collider)
    {
        // Check if object has the Player tag then check if it's inside the collider or not
        if (collider.CompareTag("Player"))
        {
            PlayerMovement player = collider.GetComponent<PlayerMovement>();
            if (player != null)
            {
                //Player inside trigger area
                Debug.Log("Player inside trigger");
                OnPlayerEnterTrigger?.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        // Check if object has the Player tag then check if it's inside the collider or not
        if (collider.CompareTag("Player"))
        {
            PlayerMovement player = collider.GetComponent<PlayerMovement>();
            if (player != null)
            {
                //Player inside trigger area
                Debug.Log("Player has exited trigger");
                OnPlayerExitTrigger?.Invoke();
            }
        }
    }
}