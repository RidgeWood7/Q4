using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.IO.Pipes;

public class SlowLever : MonoBehaviour
{
    public UnityEvent leverFlipDown;

    public UnityEvent leverFlipUp;

    public bool isSlowlyFlipping;

    public void SlowLeverInteract()
    {
        if (isSlowlyFlipping == false)
        {
            StartCoroutine(LeverFlip(GetComponentInChildren<Animator>()));
        }
    }

    IEnumerator LeverFlip(Animator leverFlip)
    {
        leverFlip.SetTrigger("Flip");

        leverFlipDown.Invoke();

        isSlowlyFlipping = true;

        yield return new WaitForSeconds(1);

        leverFlip.SetTrigger("Slow Flip");

        yield return new WaitForSeconds(30);

        isSlowlyFlipping = false;

        leverFlipUp.Invoke();
    }
}
