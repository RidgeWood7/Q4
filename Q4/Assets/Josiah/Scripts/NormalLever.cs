using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.IO.Pipes;

public class NormalLever : MonoBehaviour
{
    public UnityEvent leverInteract;

    public bool isFlipping;

    public void LeverInteract()
    {
        if (isFlipping == false)
        {
            StartCoroutine(LeverFlip(GetComponentInChildren<Animator>()));
        }
    }

    IEnumerator LeverFlip(Animator leverFlip)
    {
        leverFlip.SetTrigger("Flip");

        isFlipping = true;

        yield return new WaitForSeconds(1);

        isFlipping = false;

        leverInteract.Invoke();
    }
}