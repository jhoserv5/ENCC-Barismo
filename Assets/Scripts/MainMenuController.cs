using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour // MonoBehaviour es el extends el script se puede pegar a un objeto de la escena
{
    public void Jugar()
    {
        SceneManager.LoadScene("Cafeteria");
    }

    public void ModoPractica()
    {
        Debug.Log("Modo práctica: pendiente");
    }

    public void Configuracion()
    {
        Debug.Log("Configuración: pendiente");
    }
}