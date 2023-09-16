using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorAmbiental : MonoBehaviour
{
    public Color colorAmbiente;

    public static GestorAmbiental Instancia;

    public static event Action<Color> OnColorChange;

    private void Awake()
    {
        Instancia = this;
    }

    public void PonerColorAlEmpezar()
    {
        PonerColorAmbiente(colorAmbiente);
    }

    //La forma correcta de hacerlos, es llamar a esto cuando personaje se instancie en vez de en el start
    public void PonerColorAmbiente(Color color)
    {
        //Camera.Main hace referencia a la camara que tenga el tag de main camera
        Camera.main.backgroundColor = color;
        //Cambiamos el color ambiental
        RenderSettings.ambientLight = color;

        OnColorChange?.Invoke(color);
    }


    //void Start()
    //{
    //    //StartCoroutine(PonerColorAmbiente(colorAmbiente)); Modo sucio usando una cortutina
    //}    

    //public IEnumerator PonerColorAmbiente(Color color)  //Modo sucio de arreglar el error del color ambiental usando una corutina
    //{        
    //    //Cambiamos el color ambiental
    //    RenderSettings.ambientLight = color;
    //    yield return new WaitForSeconds(0.5f); //Esperamos medio segundo antes de continuar

    //    //Camera.Main hace referencia a la camara que tenga el tag de main camera
    //    Camera.main.backgroundColor = color;

    //    OnColorChange?.Invoke(color);
    //}
}
