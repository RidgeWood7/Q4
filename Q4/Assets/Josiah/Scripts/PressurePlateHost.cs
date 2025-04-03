using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlateHost : MonoBehaviour
{
    //things that stay the same
    private int _plateTotal = 0;
    public List<GameObject> plateList;

    //things that are changed for each puzzle
    public int plateAmount;

    private void Update()
    {
        PressurePlate.pressurePlatesActivated = _plateTotal;

        if (plateAmount > _plateTotal)
        {//this is 
        }
        if (plateAmount == _plateTotal)
        {//this will run the check for if the code was correct
            
        }
    }
}
