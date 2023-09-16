using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(ColisionesPersonajes), typeof(Controles),typeof(EstadisticasPersonaje))]
[RequireComponent(typeof(MovimientoCamara), typeof(MovimientoPersonaje), typeof(SistemaGravedad))]
[RequireComponent(typeof(SistemaRayCast))]

public class SistemasPersonaje : MonoBehaviour
{
    public static ColisionesPersonajes ColisionesPersonajes;
    public static Controles Controles;
    public static EstadisticasPersonaje EstadisticasPersonaje;
    public static MovimientoCamara MovimientoCamara;
    public static Movimientos Movimientos;
    public static SistemaGravedad SistemaGravedad;
    public static SistemaRayCast SistemaRayCast;
    public int FPS;
    public TMP_Text TextoFPS;
    private int FramesAcumulado;
    public int ActualizacionesPorSegundo;
    private float Temporizador;
    public bool Debug;

    void Awake()
    {
        ColisionesPersonajes = GetComponent<ColisionesPersonajes>();
        Controles = GetComponent<Controles>();
        EstadisticasPersonaje = GetComponent<EstadisticasPersonaje>();
        MovimientoCamara = GetComponent<MovimientoCamara>();
        Movimientos = GetComponent<Movimientos>();
        SistemaGravedad = GetComponent<SistemaGravedad>();
        SistemaRayCast = GetComponent<SistemaRayCast>();
        TextoFPS.gameObject.SetActive(Debug);
    }

    private void Start()
    {
        Comprobaciones();
    }

    private void Update()
    {
        CalcularFPS();
    }

    public void Comprobaciones()
    {
        //GestorAmbiental.Instancia.PonerColorAlEmpezar();
    }

    public void CalcularFPS()
    {
        FramesAcumulado += 1;
        Temporizador += Time.deltaTime;
        if (Temporizador >= (1f/ActualizacionesPorSegundo))
        {
            FPS = (int)(FramesAcumulado * ActualizacionesPorSegundo);
            TextoFPS.text = FPS.ToString();
            FramesAcumulado = 0;
            Temporizador = 0;
        }
    }
}
