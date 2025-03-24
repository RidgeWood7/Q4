using UnityEngine;
using System.Collections;

public abstract class Mask : MonoBehaviour
{
    public KeyCode key;
    public string maskName;

    private bool isMaskOn;

    public abstract void EquipMask();
    public abstract void UnequipMask();

    public void Update()
    {
        if (Input.GetKeyDown(key))
        {
            if (isMaskOn) 
            {
                UnequipMask();
            }
            else
            {
                EquipMask();
            }

            // Flips bool to the opposite of what it was
            isMaskOn = !isMaskOn;
        }
    }
}
