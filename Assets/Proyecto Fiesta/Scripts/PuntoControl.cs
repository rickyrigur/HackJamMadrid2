using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoControl : MonoBehaviour
{
    public bool activado;
    public float rango;
    public SphereCollider colision;

    private void Awake()
    {
        colision = GetComponent<SphereCollider>();
    }

    void Start()
    {
        colision.radius = rango;
    }

    public void Activar()
    {
        activado = true;
    }
}
