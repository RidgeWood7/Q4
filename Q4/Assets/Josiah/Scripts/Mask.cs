using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public abstract class Mask : MonoBehaviour
{
    public string maskName;

    public bool collectedMask;

    public void setCollectedMask(bool collected) => collectedMask = collected;

    public abstract void EquipMask();

    public abstract void Behaviour(PlayerMovement player);

    public abstract void UnequipMask();
}
