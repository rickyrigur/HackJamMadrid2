using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour, IConsumible
{

    public int Valor;
    public int Curacion;

    public void AlConsumir(GameObject Consumidor)
    {
        ITieneMonedas Monedero = Consumidor.GetComponent<ITieneMonedas>();
        if(Monedero != null) 
        {
            Monedero.ModificarMonedas(Valor);
        }
        IDañable Dañable = Consumidor.GetComponent<IDañable>();
        if(Dañable != null)
        {
            Dañable.ModificarVida(-Curacion);
        }
        ReproductorSonido Reproductor = GetComponent<ReproductorSonido>();
        if(Reproductor != null)
        {
            Reproductor.PonerClip();
        }
        StartCoroutine(GestorBasura.Instancia.DestruirEnXTiempo(gameObject, 2f));
    }
}
