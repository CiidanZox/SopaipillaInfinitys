using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject opcionesPag;
    public GameObject pausaPag;
    public GameObject controlesPag;
    public GameObject mapachePag;
    public GameObject chinchillaPag;
    public GameObject sonidoPag;
    public GameObject tutoPag;

    private void Start()
    {
        Time.timeScale = 0f;
        tutoPag.SetActive(true);
    }

    public void Opciones()
    {
        opcionesPag.SetActive(true);
    }

    public void Controles()
    {
        controlesPag.SetActive(true);
    }

    public void CerrarControles()
    {
        controlesPag.SetActive(false);
    }

    public void PageMapache()
    {
        mapachePag.SetActive(true);
    }

    public void CerrarPageMapache()
    {
        mapachePag.SetActive(false);
    }
    public void PageChinchilla()
    {
        chinchillaPag.SetActive(true);
    }

    public void CerrarPageChinchilla()
    {
        chinchillaPag.SetActive(false);
    }

    public void Sonido()
    {
        sonidoPag.SetActive(true);
    }

    public void CerrarSonido()
    {
        sonidoPag.SetActive(false);
    }

    public void CerrarOpciones()
    {
        opcionesPag.SetActive(false);
    }

    public void CerrarPausa()
    {
        pausaPag.SetActive(false);
        Time.timeScale = 1;
    }

    public void SalirMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void CerrarTutorial()
    {
        tutoPag.SetActive(false);
        Time.timeScale = 1f;
    }
    
}
