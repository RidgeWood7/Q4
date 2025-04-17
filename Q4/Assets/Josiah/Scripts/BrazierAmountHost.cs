using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BrazierAmountHost : MonoBehaviour
{
    //things that stay the same
    public int correctID;
    public List<BrazierAmount> plates;

    public void CheckPlates()
    {
        //this will run the check for if the code was correct
        if (correctID == PressurePlate.plateIDTotal)
        {
            BrazierAmount.complete = true;
        }
        else
        {
            PressurePlate.plateIDTotal = 0;
            plates.ForEach(item => item.ResetBraziers());
        }
    }
}
