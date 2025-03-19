using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Controller controls;
    private Vector3 velocity;
    private Vector2 move;
    private CharacterController controller;
    private bool isGrounded;

    private float moveSpeed = 10f;
    private float gravity = -9.81f;
    private float jumpHeight = 2.4f;

    public Transform ground;
    public LayerMask groundMask;
    public float radius = 0.4f;

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(ground.position, radius);
    }

    private void Awake()
    {
        controls = new Controller();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Gravity();
        Movement();
        jumpH();
    }

    private void Gravity()
    {
        isGrounded = Physics.CheckSphere(ground.position, radius, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Movement(){
        move = controls.Player.Move.ReadValue<Vector2>();

        Vector3 distance = (move.y * transform.forward) + (move.x * transform.right);
        controller.Move(distance * moveSpeed * Time.deltaTime);
    }

    private void jumpH(){
        if(controls.Player.Jump.triggered && isGrounded == true){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void OnEnable(){
        controls.Enable();
    }

    private void OnDisable(){
        controls.Disable();
    }
}
