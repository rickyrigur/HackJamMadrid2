using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientos : MonoBehaviour
{    
    public float velocidadBase = 2;
    float VelocidadMod = 1;
    public float velocidadFinal;
    public float modCorrer;
    public float distanciaSalto;
    public Vector3 direccionFinal;
    public Vector3 direccionXZ;
    public float saltosMaximos;
    float saltosActuales;

    Rigidbody Personaje;

    private void Awake()
    {
        Personaje = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        velocidadBase = 2;
        CalcularVelocidad();
    }

    private void FixedUpdate()
    {
        Movimiento();
    }

    private void Update()
    {
        
    }

    public void Movimiento()
    {
        direccionXZ = new Vector3(SistemasPersonaje.Controles.EjeX, 0, SistemasPersonaje.Controles.EjeZ).normalized * velocidadFinal;
        direccionFinal = direccionXZ + Vector3.up * SistemasPersonaje.SistemaGravedad.EjeY;

        //TransformDirection convierte la direccion global en local
        Personaje.velocity = transform.TransformDirection(direccionFinal);
    }
    public void Saltar()
    {
        if (SistemasPersonaje.SistemaGravedad.enSuelo)
            saltosActuales = 0;

        if (SistemasPersonaje.SistemaGravedad.enSuelo == false && saltosActuales >= saltosMaximos)
            return;

        //Saltamos poniendo el ejeY en positivo, debemos usar una formula matematica para saber
        //que fuerza necesitamos para llegar a la distanciaSalto
        SistemasPersonaje.SistemaGravedad.EjeY = Mathf.Sqrt(distanciaSalto * -2 * SistemasPersonaje.SistemaGravedad.gravedad);
        saltosActuales++;
    }

    public void Correr(bool corriendo)
    {
        //if(corriendo)
        //    VelocidadMod = modCorrer;  
        //else
        //    VelocidadMod = 1;

        VelocidadMod = corriendo ? modCorrer : 1;

        CalcularVelocidad();
    }

    public void CalcularVelocidad()
    {
        velocidadFinal = velocidadBase * VelocidadMod;
    }
}
