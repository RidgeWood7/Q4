using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 velocity;
    private Vector2 move;
    [HideInInspector] public CharacterController controller;
    private bool isGrounded;
    private float movementWeightX = 1f;
    private float movementWeightY = 1f;
    public float airWeightX = .5f;
    public float airWeightY = .5f;

    private float moveSpeed = 10f;
    private float gravity = -9.81f;
    private float jumpHeight = 2.4f;

    public Transform ground;
    public LayerMask groundMask;
    public Vector3 size;

    public Mask currentMask;

    private Mask[] masks;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(ground.position, size);
    }



    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        masks = GetComponents<Mask>();

        if (currentMask)
        {
            currentMask.EquipMask();
        }
    }

    void Update()
    {
        Gravity();
        MaskBehaviour();

        Vector3 distance = (movementWeightY * move.y * transform.forward) + (movementWeightX * move.x * transform.right);
        controller.Move(distance * moveSpeed * Time.deltaTime);

        movementWeightX = isGrounded ? 1f : airWeightX;
        movementWeightY = isGrounded ? 1f : airWeightY;
    }

    public void MoonMask(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 0)
            return;

        if (masks[0] == currentMask)
        {
            currentMask.UnequipMask();
            currentMask = null;

            return;
        }

        if (currentMask)
        {
            currentMask.UnequipMask();
        }

        if (masks[0].collectedMask == true)
        {
            currentMask = masks[0];

            currentMask.EquipMask();
        }
    }

    public void SunMask(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 0)
            return;

        if (masks[1] == currentMask)
        {
            currentMask.UnequipMask();
            currentMask = null;

            return;
        }

        if (currentMask)
        {
            currentMask.UnequipMask();
        }

        if (masks[1].collectedMask == true)
        {
            currentMask = masks[1];

            currentMask.EquipMask();
        }
    }

    public void LeafMask(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 0)
            return;

        if (masks[2] == currentMask)
        {
            currentMask.UnequipMask();
            currentMask = null;

            return;
        }

        if (currentMask)
        {
            currentMask.UnequipMask();
        }

        if (masks[2].collectedMask == true)
        {
            currentMask = masks[2];

            currentMask.EquipMask();
        }
    }

    private void MaskBehaviour()
    {
        if (currentMask)
        {
            currentMask.Behaviour(this);
        }
    }

    private void Gravity()
    {
        isGrounded = Physics.CheckBox(ground.position, size, Quaternion.identity, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void Movement(InputAction.CallbackContext ctx)
    {
        move = ctx.ReadValue<Vector2>();
    }

    public void jumpH(InputAction.CallbackContext ctx)
    {
        float finalJumpH = jumpHeight;

        if (currentMask is LeafMask leafMask)
        {
            if (ctx.ReadValue<float>() == 0 && isGrounded == true)
            {
                finalJumpH *= leafMask.currentJumpHeight;
                velocity.y = Mathf.Sqrt(finalJumpH * -2f * gravity);
            }
        }
        else
        {
            if (ctx.ReadValue<float>() == 1 && isGrounded == true)
            {

                velocity.y = Mathf.Sqrt(finalJumpH * -2f * gravity);
            }
        }
    }
}
