using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorEscena : MonoBehaviour
{
    public static GestorEscena Instancia;

    void Awake()
    {
        Instancia = this;
    }

    public void CambiarEscena(int ID)
    {
        SceneManager.LoadScene(ID);
    }

    public void Salir()
    {
        print("SALIR");
        Application.Quit();
    }
}
