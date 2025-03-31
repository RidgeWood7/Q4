using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Controller controls;
    private Vector3 velocity;
    private Vector2 move;
    [HideInInspector]public CharacterController controller;
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
        controls = new Controller();
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
        Movement();
        jumpH();
        MaskBehaviour();

        movementWeightX = isGrounded ? 1f : airWeightX;
        movementWeightY = isGrounded ? 1f : airWeightY;
    }

    private void MaskBehaviour()
    {

        if (currentMask)
        {
            currentMask.Behaviour(this);
        }

        // To-do: iterate through masks and look for button press

        foreach (Mask mask in masks)
        {
            if (Input.GetKeyDown(mask.key))
            {
                if (mask == currentMask)
                {
                    currentMask.UnequipMask();
                    currentMask = null;

                    break;
                }

                if (currentMask)
                {
                    currentMask.UnequipMask();
                }

                currentMask = mask;

                currentMask.EquipMask();
            }
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

    private void Movement(){
        move = controls.Player.Move.ReadValue<Vector2>();

        Vector3 distance = (movementWeightY * move.y * transform.forward) + (movementWeightX * move.x * transform.right);
        controller.Move(distance * moveSpeed * Time.deltaTime);
    }

    private void jumpH(){
        float finalJumpH = jumpHeight;

        if (currentMask is LeafMask leafMask)
        {
            if (controls.Player.Jump.WasReleasedThisFrame() && isGrounded == true)
            {
                finalJumpH *= leafMask.currentJumpHeight;
                velocity.y = Mathf.Sqrt(finalJumpH * -2f * gravity);
            }
        }
        else
        {
            if (controls.Player.Jump.triggered && isGrounded == true)
            {

                velocity.y = Mathf.Sqrt(finalJumpH * -2f * gravity);
            }
        }
    }

    private void OnEnable(){
        controls.Enable();
    }

    private void OnDisable(){
        controls.Disable();
    }
}
