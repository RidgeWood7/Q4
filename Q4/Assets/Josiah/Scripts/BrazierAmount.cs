using NUnit.Framework;
using UnityEngine;

public class BrazierAmount : MonoBehaviour
{
    public static int brazierIDTotal;
    public static bool complete = false;
    public int brazierIDNum;

    public bool isLit = false;

    private void Update()
    {
        if (complete)
        {
            Debug.Log("COMPLETE");
        }
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Player") && !isLit)
        {
            Light();
        }
    }

    public void Light()
    {
        isLit = true;

        brazierIDTotal = brazierIDTotal + brazierIDNum;
    }

    public void ResetBraziers()
    {
        isLit = false;
    }
}