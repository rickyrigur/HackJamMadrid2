using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuscarObjetos : MonoBehaviour
{
    GameObject Objeto;
    Rigidbody RigidBody;
    Renderer Renderer;

    //Hay varias formas de buscar un objeto o componente en Unity, jamas debe hacerse en Update
    // Start is called before the first frame update
    void Start()
    {
        //Todas las busquedas tienen su version de buscar una lista poniendo "S", todas nos devovleran el 
        //primer objeto de la jerarquia
        //Buscar por nombre, es el menos optimo
        Objeto = GameObject.Find("NombreDelObjeto");

        //Buscar por tag
        Objeto = GameObject.FindGameObjectWithTag("MainCamera");

        //Buscar por tipo
        RigidBody = FindFirstObjectByType<Rigidbody>();

        //Buscar componente, este si se puede hacer en Update
        Renderer = GetComponent<Renderer>();
    }

}
