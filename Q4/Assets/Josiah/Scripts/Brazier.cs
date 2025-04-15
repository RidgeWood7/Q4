using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Brazier : MonoBehaviour
{
    public static List<GameObject> yourOrder = new();

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Flame")) 
        {
            LightBrazier();
        }
    }

    private void LightBrazier()
    {
        yourOrder.Add(gameObject);
        Debug.Log("This brazier is lit!");
    }
}
