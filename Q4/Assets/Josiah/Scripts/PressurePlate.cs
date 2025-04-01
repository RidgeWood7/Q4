using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool isSunken;

    public Animator plateAnimator;

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Sink();
        }
    }

    void Sink()
    {
        isSunken = true;

        plateAnimator.SetTrigger("Interact");
    }
}
