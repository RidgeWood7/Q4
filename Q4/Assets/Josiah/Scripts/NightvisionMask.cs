using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class NightvisionMask : Mask
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask maskOff;
    [SerializeField] private LayerMask maskOn;
    [SerializeField] private Color maskColor;

    public override void EquipMask()
    {
        cam.cullingMask = maskOn;

        var volume = cam.GetComponent<Volume>().sharedProfile;

        if (volume.TryGet(out ColorAdjustments color))
        {
            color.colorFilter.Override(maskColor);
        }
    }

    public override void UnequipMask()
    {
        cam.cullingMask = maskOff;

        var volume = cam.GetComponent<Volume>().sharedProfile;

        if (volume.TryGet(out ColorAdjustments color))
        {
            color.colorFilter.Release();
        }
    }

}
