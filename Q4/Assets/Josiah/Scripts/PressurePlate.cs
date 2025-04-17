using NUnit.Framework;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public static int plateIDTotal;
    public static bool platesComplete = false;
    public int plateIDNum;

    public bool isSunken = false;

    public Animator plateAnimator;

    private void Update()
    {
        if (platesComplete)
        {
            plateAnimator.SetTrigger("Player Step");
            Debug.Log("COMPLETE");
        }
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Player") && !isSunken)
        {
            Sink();
        }
    }

    public void Sink()
    {
        isSunken = true;

        plateIDTotal = plateIDTotal + plateIDNum;

        plateAnimator.SetTrigger("Player Step");
    }

    public void ResetPressurePlates()
    {
        plateAnimator.SetTrigger("Reset");

        isSunken = false;
    }
}
