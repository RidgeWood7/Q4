using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MoonMask : Mask
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask maskOff;
    [SerializeField] private LayerMask maskOn;
    [SerializeField] private Color maskColor;
    public Animator maskAnimations;

    public override void EquipMask()
    {
        cam.cullingMask = maskOn;

        var volume = cam.GetComponent<Volume>().profile;

        if (volume.TryGet(out ColorAdjustments color)&& volume.TryGet(out ChromaticAberration chromaticAberration))
        {
            StartCoroutine(FadeIn(color, chromaticAberration));
        }
    }

    private IEnumerator FadeIn(ColorAdjustments color, ChromaticAberration chromaticAberration)
    {
        for (int i = 0; i < 20; i++)
        {
            color.colorFilter.Override(Color.Lerp(Color.white, maskColor, i / 20.0f));
            chromaticAberration.intensity.Override(Mathf.Lerp(0, 0.5f, i / 20.0f));
            yield return new WaitForSeconds(0.025f);
        }
    }

    public override void UnequipMask()
    {
        cam.cullingMask = maskOff;

        var volume = cam.GetComponent<Volume>().profile;

        if (volume.TryGet(out ColorAdjustments color) && volume.TryGet(out ChromaticAberration chromaticAberration))
        {
            StartCoroutine (FadeOut(color, chromaticAberration));

        }
    }

    private IEnumerator FadeOut(ColorAdjustments color, ChromaticAberration chromaticAberration)
    {
        for (int i = 0; i < 20; i++)
        {
            color.colorFilter.Override(Color.Lerp(maskColor, Color.white, i / 20.0f));
            chromaticAberration.intensity.Override(Mathf.Lerp(0.5f, 0, i / 20.0f));
            yield return new WaitForSeconds(0.025f);
        }
    }

    public override void Behaviour()
    {
    }
}
