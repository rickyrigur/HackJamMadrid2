using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float Velocidad = 2;
    public Vector3 DireccionXZ;
    public Vector3 DireccionFinal;
    public float DistanciaSalto;
    public float SaltosMaximos;
    public bool animacionEnCurso;
    int derecha = 90;
    int izquierda = 270;


    Controles Controles;
    SistemaGravedad SistemaGravedad;
    SistemaRayCast SistemaRaycast;
    Rigidbody Personaje;
    Transform Doctor;

    private void Awake()
    {
        Controles = GetComponent<Controles>();
        SistemaGravedad = GetComponent<SistemaGravedad>();
        Personaje = GetComponent<Rigidbody>();
        SistemaRaycast = GetComponent<SistemaRayCast>();
    }

    private void FixedUpdate()
    {
        Movimiento();
    }

    public void Movimiento()
    {
        if (!animacionEnCurso)
        {
            DireccionXZ = new Vector3(Controles.EjeX, 0, Controles.EjeZ).normalized * Velocidad;
            DireccionFinal = DireccionXZ + new Vector3(0, SistemaGravedad.EjeY, 0);
            //TransfromDirection convierte de global a local

            //RotarPersonaje();

            Personaje.velocity = transform.TransformDirection(DireccionFinal);
        }
    }    

    public void RotarPersonaje()
    {
        if (DireccionFinal.x > 0)
        {
            Doctor.eulerAngles = new Vector3(0, derecha, 0);
        }
        else if (DireccionFinal.x < 0)
        {
            Doctor.eulerAngles = new Vector3(0, izquierda, 0);
        }
    }   
    
}
