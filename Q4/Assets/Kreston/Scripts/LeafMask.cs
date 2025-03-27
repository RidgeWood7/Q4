using System.Collections;
using UnityEngine;

public class LeafMask : Mask
{
    public float jumpMult;


    private void Start()
    {
    }

    private void Update()
    {
    }

    public override void EquipMask()
    {
        StartCoroutine(FOVup());
    }

    public override void UnequipMask()
    {
        StartCoroutine (FOVdown());
    }

    public override void Behaviour()
    {
    }


    private IEnumerator FOVup()
    {
        for (int i = 0; i < 20; i++)
        {
            Camera.main.fieldOfView = Mathf.Lerp(75, 90, i/20f);
            yield return new WaitForSeconds(.01f);
        }
    }

    private IEnumerator FOVdown()
    {
        for (int i = 0; i < 20; i++)
        {
            Camera.main.fieldOfView = Mathf.Lerp(90, 75, i / 20f);
            yield return new WaitForSeconds(.005f);
        }
    }

    private IEnumerator JumpChargeUp()
    {
        for (int i = 0; i < 20; i++)
        {
            
            yield return new WaitForSeconds(.025f);
        }
    }
}
