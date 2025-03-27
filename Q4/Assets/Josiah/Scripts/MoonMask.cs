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

        // Takes camera's volume profile in order to make changes to it
        var volume = cam.GetComponent<Volume>().profile;

        // TryGet accesses component if the object it's attached to has that component. Returns a true bool if it has it, returns a false bool if it doesn't
        if (volume.TryGet(out ColorAdjustments color)&& volume.TryGet(out ChromaticAberration chromaticAberration))
        {
            // Starts FadeIn coroutine when you equip the mask. Passes in color filter and chromatic aberration in order to change them
            StartCoroutine(FadeIn(color, chromaticAberration));
        }
    }

    // All coroutines start with IEnumerator. Runs code when you want it instead of the way unity wants it. Allows you to control timing of code
    private IEnumerator FadeIn(ColorAdjustments color, ChromaticAberration chromaticAberration)
    {
        // Makes code happen 20 times
        for (int i = 0; i < 20; i++)
        {
            // Lerps value between white and the mask color over time
            color.colorFilter.Override(Color.Lerp(Color.white, maskColor, i / 20.0f));
            // Lerps the intensity between 0 and 5
            chromaticAberration.intensity.Override(Mathf.Lerp(0, 0.5f, i / 20.0f));
            // Forces the code to happen over time
            yield return new WaitForSeconds(0.025f);
        }
    }

    public override void UnequipMask()
    {
        // Turns off the "Invisible" culling mask so you can't see it
        cam.cullingMask = maskOff;

        var volume = cam.GetComponent<Volume>().profile;

        if (volume.TryGet(out ColorAdjustments color) && volume.TryGet(out ChromaticAberration chromaticAberration))
        {
            StartCoroutine (FadeOut(color, chromaticAberration));

        }
    }

    // Does the opposite of the other coroutine since the numbers are flipped
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