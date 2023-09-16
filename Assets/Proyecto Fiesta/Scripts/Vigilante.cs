using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vigilante : MonoBehaviour, IDisparar
{
    // Este script contendrá el código de cómo nuestro vigilante detecta cosas

    public SphereCollider RangoDeteccion;
    public SphereCollider RangoContacto;
    public float DistanciaVision;
    public GameObject ObjetoARotar;
    public GameObject Bala;
    public GameObject SalidaBala;
    public SistemasPersonaje Objetivo;
    public float TiempoEntreDisparos;
    public float Temporizador;
    public Light LuzTorreta;
    public Color ColorTorreta;

    public List<Collider> ObjetosAIgnorarBala;


    void Awake()
    {
        RangoDeteccion.radius = DistanciaVision;
        LuzTorreta.color = ColorTorreta;
    }
    
    void Update()
    {
        Comportamiento();
    }

    public void Comportamiento()
    {
        if(Objetivo)
        {
            ObjetoARotar.transform.LookAt(Objetivo.transform);
            ComprobarSiPuedoDisparar();
        }
        SistemaTiempo();
    }
    public void DetectarObjetivo(SistemasPersonaje personaje)
    {
        Objetivo = personaje;
    }

    public void LiberarObjetivo()
    {
        Objetivo = null;
    }

    public void ComprobarSiPuedoDisparar()
    {
        if(Temporizador >= TiempoEntreDisparos)
        {
            //Disparar();
            Temporizador = 0;
        }
    }

    public void SistemaTiempo()
    {
        Temporizador += Time.deltaTime;
    }

    //public void Disparar()
    //{
    //    Bala BalaNueva = Instantiate(Bala, SalidaBala.transform.position, ObjetoARotar.transform.rotation).GetComponent<Bala>();
    //    BalaNueva.Dueño = this;
    //    BalaNueva.ColorBala = ColorTorreta;
    //    ObjetosAIgnorarBala.Add(BalaNueva.Colision);

    //    CancelarColisiones(BalaNueva.Colision);
    //}

    public void CancelarColisiones(Collider Bala)
    {
        for(int i = 0; i < ObjetosAIgnorarBala.Count; i++)
        {
            Physics.IgnoreCollision(Bala, ObjetosAIgnorarBala[i], true);
        }
    }

    private void OnTriggerEnter(Collider Colision)
    {
        SistemasPersonaje Personaje = Colision.GetComponent<SistemasPersonaje>();
        if (Personaje != null)
        {
            DetectarObjetivo(Personaje);
        }
    }

    private void OnTriggerExit(Collider Colision)
    {
        SistemasPersonaje Personaje = Colision.GetComponent<SistemasPersonaje>();
        if (Personaje != null)
        {
            LiberarObjetivo();
        }
    }

    public void LimpiarLista(Collider Objeto)
    {
        ObjetosAIgnorarBala.Remove(Objeto);
    }
}
