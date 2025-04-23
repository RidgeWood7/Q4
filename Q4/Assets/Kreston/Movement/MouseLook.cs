using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;

    private Vector2 mouseLook;
    private Transform playerBody;


    private void Awake()
    {
        playerBody = transform.parent;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = mouseLook.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseLook.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void Look(InputAction.CallbackContext ctx)
    {
        mouseLook = ctx.ReadValue<Vector2>();
    }
}
