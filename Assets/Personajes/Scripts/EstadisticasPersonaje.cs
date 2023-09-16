using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EstadisticasPersonaje : MonoBehaviour, IDañable, ITieneMonedas, IPuedeMorir
{
    public Slider sliderVida;
    public TMP_Text TextoMonedas;
    public Inventario Inventario;
    public Estadisticas Estadisticas;

    void Start()
    {
        ModificarVida(0);
        ActualizarInterfaz();
    }

    public void ModificarVida(float cantidad)
    {
        Estadisticas.ModificarVida(cantidad);
        ActualizarSliderVida();
    }

    public void ActualizarInterfaz()
    {
        ActualizarSliderVida();
    }

    public void ActualizarSliderVida()
    {
        sliderVida.maxValue = Estadisticas.vidaMaxima;
        sliderVida.value = Estadisticas.vidaActual;
    }

    public void ModificarMonedas(int Cantidad)
    {
        Inventario.ModificarMonedas(Cantidad);
        TextoMonedas.text = "Monedas: " + Inventario.Monedas.ToString("D4");
    }

    public void AlMorir()
    {
        //Al morir hay que decidir qué hacer con el personaje
        GestorEscena.Instancia.CambiarEscena(SceneManager.GetActiveScene().buildIndex);
    }
}
