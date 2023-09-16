using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionFashonista : MonoBehaviour
{
    public GameObject Indicador;

    private void Start()
    {
        Indicador.SetActive(false);
    }

    private void OnMouseOver()
    {
        Indicador.SetActive(true);
    }

    private void OnMouseExit()
    {
        Indicador.SetActive(false);
    }
}
