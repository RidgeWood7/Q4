using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BrazierPuzzle : MonoBehaviour
{
    public List<GameObject> correctOrder;

    private void Update()
    {

    }

    // Uses T instead of GameObject so that it can be any variable types including GameObkects
    // Goes through both the lists until it reaches the end amount to make sure they are both the same
    public static bool CompareLists<T>(List<T> listA, List<T> listB)
    {
        if (listA.Count != listB.Count) return false;

        for (int i = 0; i < listA.Count && i < listB.Count; i++)
        {
            if (!listA[i].Equals(listB[i]))
            {
                return false;
            }
        }

        return true;
    }

    public void ResetOrder()
    {
        Brazier.yourOrder.Clear();
    }
}
