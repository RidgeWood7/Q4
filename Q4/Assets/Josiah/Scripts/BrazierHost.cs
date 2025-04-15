using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BrazierPuzzle : MonoBehaviour
{
    public List<GameObject> correctOrder;

    private void Update()
    {
        if (correctOrder[0] == Brazier.yourOrder[0] && correctOrder[1] == Brazier.yourOrder[1] && correctOrder[2] == Brazier.yourOrder[2])
        {
            Debug.Log("Good job jittleyang!");
        }
    }
}
