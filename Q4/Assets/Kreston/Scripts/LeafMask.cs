using System.Collections;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeafMask : Mask
{
    public float jumpMult;
    public float jumpChargeTime = .02f;

    [HideInInspector] public float currentJumpHeight;



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

    public override void Behaviour(PlayerMovement player)
    {
        if (collectedMask == true)
        {
            Coroutine jump = null;
            if (player.GetComponent<PlayerInput>().actions["Jump"].triggered)
            {
                jump = StartCoroutine(JumpChargeUp());
            }

            if (jump is not null && player.GetComponent<PlayerInput>().actions["Jump"].WasReleasedThisFrame())
            {
                StopCoroutine(jump);
            }
        }
    }


    private IEnumerator FOVup()
    {
        Debug.Log("help");
        for (int i = 0; i < 20; i++)
        {
            Camera.main.fieldOfView = Mathf.Lerp(75, 90, i/20f);
            yield return new WaitForSeconds(.01f);
        }
    }

    private IEnumerator FOVdown()
    {
        Debug.Log("me");
        for (int i = 0; i < 20; i++)
        {
            Camera.main.fieldOfView = Mathf.Lerp(90, 75, i / 20f);
            yield return new WaitForSeconds(.005f);
        }
    }

    private IEnumerator JumpChargeUp()
    {
        currentJumpHeight = 1;
        for (int i = 0; i < 20; i++)
        {
            currentJumpHeight = Mathf.Lerp(1, jumpMult, i / 20f);
            yield return new WaitForSeconds(jumpChargeTime);
        }
        Debug.Log("Charged!");
    }
}
