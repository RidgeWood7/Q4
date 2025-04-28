using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Brazier : MonoBehaviour
{
    public static List<GameObject> yourOrder = new();

    private void OnCollisionExit(Collision collider)
    {
        if (collider.gameObject.CompareTag("Flame")) 
        {
            LightBrazier();
        }
    }

    public void LightBrazier()
    {
        yourOrder.Add(transform.parent.gameObject);
        Debug.Log("This brazier is lit!");
    }

    public void CheckOrder()
    {
        if (BrazierPuzzle.CompareLists(yourOrder, FindFirstObjectByType<BrazierPuzzle>().correctOrder))
        {
            Debug.Log("This is correct");
        }

        else
        {
            FindFirstObjectByType<BrazierPuzzle>().ResetOrder();
        }
    }
}
