using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool isSunken;

    public static int pressurePlatesActivated;

    public bool important;

    public Animator plateAnimator;

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Sink();
        }
    }

    public void Sink()
    {
        isSunken = true;

        pressurePlatesActivated ++;

        plateAnimator.SetTrigger("Player Step");
    }

    public void ResetPressurePlates()
    {
        pressurePlatesActivated = 0;

        plateAnimator.SetTrigger("Reset");
    }

    public void CheckIfCorrect()
    {
        if (important == true)
        {
            
        }

        else
        {
            ResetPressurePlates();
        }
    }

    public void SetAsImportant()
    {
        important = true;
    }
}
