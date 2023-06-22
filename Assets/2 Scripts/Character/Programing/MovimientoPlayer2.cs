using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float gravity = 20f;
    public GameObject boton2;
    public GameObject boton4;
    public GameObject pared2;
    public GameObject pared3;
    public GameObject piso1;
    public GameObject piso2;
    public GameObject pauseMenu;

    private CharacterController controller;
    private bool isJumping = false;
    private Vector3 velocity;
    private float mouseSensitivity = 2f;
    private float verticalRotation = 0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        piso1.SetActive(true);
        piso2.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Vertical");
        float verticalInput = Input.GetAxis("Horizontal1");
        verticalInput *= -1f;

        Vector3 movement = new Vector3(verticalInput * moveSpeed, 0f, horizontalInput * moveSpeed);
        movement = transform.TransformDirection(movement);
        controller.Move(movement * Time.deltaTime);
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0f, mouseX, 0f);
        
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // Limitar la rotación vertical de la cámara
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f); // Rotar la cámara
        
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Mathf.Abs(transform.localScale.z));
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Mathf.Abs(transform.localScale.z));
        }

        if (controller.isGrounded)
        {
            velocity.y = -gravity * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = Mathf.Sqrt(jumpForce * 2f * gravity);
                isJumping = true;
            }
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }

        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boton2"))
        {
            Destroy(boton2);
            Destroy(pared2);
            Destroy(pared3);
        }

        if (other.CompareTag("Boton4"))
        {
            Destroy(boton4);
            Destroy(piso1);
            piso2.SetActive(true);
        }
    }
}
