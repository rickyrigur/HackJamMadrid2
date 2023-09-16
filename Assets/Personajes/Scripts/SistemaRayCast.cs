using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaRayCast : MonoBehaviour
{
    public float alto, ancho;

    void Start()
    {
        CalcularMedidas();
    }

    void Update()
    {
        DetectarSuelo();
    }

    void DetectarSuelo()
    {
        //Un Raycast es un rayo, los datos que este devuelven, se guardan en una variable llamada RaycastHit
        RaycastHit Datos;

        //raycast devuelve true si este choca con algo y false si no
        //Physics.Raycast(Inicio, direccion, salida, tamaño)
        //Spherecast(origen, radio, direccion, salida, distancia, tamaño)
        if(Physics.SphereCast(transform.position, (ancho/2), -transform.up, out Datos, (alto/2 - ancho/2 + 0.01f)))
        {
            SistemasPersonaje.SistemaGravedad.enSuelo = true;
            Debug.DrawRay(transform.position, - transform.up * (Datos.distance + ancho / 2f), Color.red);
        }
        else
        {
            SistemasPersonaje.SistemaGravedad.enSuelo = false;
            Debug.DrawRay(transform.position, -transform.up * (alto / 2  + 0.01f), Color.blue);
        }
    }

    public void CalcularMedidas()
    {
        alto = GetComponent<CapsuleCollider>().bounds.size.y;
        ancho = GetComponent<CapsuleCollider>().bounds.size.x;
    }
}
