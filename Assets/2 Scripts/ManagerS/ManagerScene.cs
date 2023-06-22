using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{

   public GameObject creditos;
   public GameObject libroAbierto;
   
   public void Jugar()
   {
      SceneManager.LoadScene("Start");
   }

   public void Menu()
   {
      SceneManager.LoadScene("Menu");
   }

   public void AbrirLibro()
   {
      libroAbierto.SetActive(true);
   }

   public void CerrarLibro()
   {
      libroAbierto.SetActive(false);
   }

   public void Creditos()
   {
      creditos.SetActive(true);
   }

   public void SacarCreditos()
   {
      creditos.SetActive(false);
   }
   
   public void Opciones()
   {
      SceneManager.LoadScene("Opciones");
   }

   public void Salir()
   {
      Application.Quit();
   }
}
