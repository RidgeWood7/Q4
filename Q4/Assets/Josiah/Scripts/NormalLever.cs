using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.IO.Pipes;

public class NormalLever : MonoBehaviour
{
    public UnityEvent leverInteract;

    public void Interact()
    {
        StartCoroutine(LeverFlipUp(GetComponentInChildren<Animator>()));
    }

    IEnumerator LeverFlipUp(Animator leverUp)
    {
        leverUp.SetTrigger("Flip");

        yield return new WaitUntil(() => leverUp.GetNextAnimatorStateInfo(0).normalizedTime>=1);

        leverInteract.Invoke();
    }
}
