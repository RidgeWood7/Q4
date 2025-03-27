using UnityEngine;
using System.Collections;

public abstract class Mask : MonoBehaviour
{
    public KeyCode key;
    public string maskName;

    public abstract void EquipMask();

    public abstract void Behaviour();

    public abstract void UnequipMask();
}
