using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiaEscenas : MonoBehaviour,IColisionable
{
    public int EscenaObjetivo;

    public void AlColisionar()
    {
        print("ENTRO");
        GestorEscena.Instancia.CambiarEscena(EscenaObjetivo);
    }
}
