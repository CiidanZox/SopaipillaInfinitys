 using System;
 using System.Collections;
using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
 using UnityEngine.SceneManagement;

public class MovimientoPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float fuerzaTrampo = 10f;
    public float gravity = 20f;
    public GameObject boton1;
    public GameObject boton3;
    public GameObject boton5;
    public GameObject pared1;
    public GameObject pared4;
    public GameObject pauseMenu;
    public List<Image> lifeImages;

    private CharacterController controller;
    private bool isJumping = false;
    private Vector3 velocity;
    private int lives = 3;
    private bool isBlinking = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput * moveSpeed, 0f, 0f);
        controller.Move(movement * Time.deltaTime);

        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Mathf.Abs(transform.localScale.z));
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -Mathf.Abs(transform.localScale.z));
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            velocity.y = Mathf.Sqrt(jumpForce * 2f * gravity);
            controller.Move(Vector3.up * jumpForce * Time.deltaTime);
            isJumping = true;
        }

        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (controller.isGrounded)
        {
            velocity.y = -gravity * Time.deltaTime;
            isJumping = false;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    void Jump()
    {
        velocity.y = Mathf.Sqrt(fuerzaTrampo * 2f * gravity);
        controller.Move(Vector3.up * fuerzaTrampo * Time.deltaTime);
        isJumping = true;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Trampolin"))
        {
            Jump();
        }
        
        if (other.CompareTag("Boton1"))
        {
            Destroy(boton1);
            Destroy(pared1);
        }

        if (other.CompareTag("Boton3"))
        {
            Destroy(pared4);
            Destroy(boton3);
        }

        if (other.CompareTag("Boton5"))
        {
            Destroy(boton5);
            SceneManager.LoadScene("End");
        }

        if (other.CompareTag("Enemy"))
        {
            // Reducir las vidas y parpadear el personaje
            lives--;
            if (lives <= 0)
            {
                // Game over
                SceneManager.LoadScene("Lost");
            }
            else
            {
                StartCoroutine(BlinkRoutine());
                RemoveLifeImage();
            }
        }
    }

    IEnumerator BlinkRoutine()
    {
        if (isBlinking)
            yield break;

        isBlinking = true;

        int blinkCount = 4;
        float blinkDuration = 0.2f;
        float blinkInterval = 0.2f;

        List<Image> lifeImagesCopy = new List<Image>(lifeImages); // Crear una copia de la lista

        foreach (Image lifeImage in lifeImagesCopy)
        {

            if (lifeImage != null)
            {
                lifeImage.enabled = false;
                yield return new WaitForSeconds(blinkDuration);
                lifeImage.enabled = true;
                yield return new WaitForSeconds(blinkInterval);
            }
        }

        isBlinking = false;
    }

    void RemoveLifeImage()
    {
        if (lifeImages.Count > 0)
        {
            Image lifeImage = lifeImages[lifeImages.Count - 1];
            lifeImages.RemoveAt(lifeImages.Count - 1);

            if (lifeImage != null)
            {
                Destroy(lifeImage.gameObject);
            }
        }
    }
}
