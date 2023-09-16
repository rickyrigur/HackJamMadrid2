using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaGravedad : MonoBehaviour
{
    public float gravedad = -9.82f;
    public bool enSuelo;
    public float limiteVelocidadCaida;

    public float EjeY;

    // Update is called once per frame
    void Update()
    {
        CalcularGravedad();
    }

    public void CalcularGravedad()
    {
        //Si estamos en el suelo y cayendo 
        if(enSuelo && EjeY <= 0)
        {
            EjeY = 0;
        }
        else
        {
            if (EjeY <= limiteVelocidadCaida)
            {
                return;
            }
            EjeY += gravedad * Time.deltaTime;            
        }
    }
}
