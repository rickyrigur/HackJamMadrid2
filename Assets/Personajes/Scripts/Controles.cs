using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour
{
    public float EjeX, EjeZ;
    public float RatonX, RatonY;

    MovimientoPersonaje MovimientoPersonaje;
    //PersonajeAnimator personajeAnimator;
    SistemaGravedad sistemaGravedad;

    private void Awake()
    {
        MovimientoPersonaje = GetComponent<MovimientoPersonaje>();
        //personajeAnimator = GetComponent<PersonajeAnimator>();
        sistemaGravedad = GetComponent<SistemaGravedad>();
    }

    private void Start()
    {

    }
    void Update()
    {
        ControlesFuncion();
        //if (!personajeAnimator.isMuerto)
        //    ControlesFuncion();
    }
    void ControlesFuncion()
    {
        EjeX = Input.GetAxisRaw("Horizontal");
        EjeZ = Input.GetAxisRaw("Vertical");
        RatonX = Input.GetAxis("Mouse X");
        RatonY = Input.GetAxis("Mouse Y");
        bool ForwardPress = Input.GetKey("d");
        bool BackPress = Input.GetKey("a");
        bool Attack = Input.GetKeyDown(KeyCode.Mouse0);
        bool Curar = Input.GetKey("e");
    }
}
