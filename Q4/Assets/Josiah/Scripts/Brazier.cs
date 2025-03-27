using UnityEngine;

public class Brazier : MonoBehaviour
{
    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Flame")) 
        {
            LightBrazier();
        }
    }

    private void LightBrazier()
    {
        Debug.Log("This brazier is lit!");
    }
}
