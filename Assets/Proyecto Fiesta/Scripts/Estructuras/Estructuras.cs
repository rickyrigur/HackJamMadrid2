using UnityEngine;

[System.Serializable]
public struct Estadisticas
{
    public float vidaActual;
    public float vidaPerdida;
    public float vidaMaxima;

    public GameObject Dueño;

    public void ModificarVida(float cantidad)
    {
        vidaPerdida += cantidad;
        CalcularVida();
    }

    public void CalcularVida()
    {
        vidaPerdida = Mathf.Clamp(vidaPerdida, 0, vidaMaxima);
        vidaActual = vidaMaxima - vidaPerdida;
        if(vidaActual == 0)
        {
            MeMuero();
        }
    }

    public void MeMuero()
    {
        IPuedeMorir Morido = Dueño.GetComponent<IPuedeMorir>();
        if (Morido != null)
        {
            Morido.AlMorir();
        }
    }

}

[System.Serializable]
public struct  Inventario
{
    public int Monedas;
    
    public void ModificarMonedas(int Cantidad)
    {
        Monedas += Cantidad;
        Monedas = Mathf.Clamp(Monedas, 0, Monedas);
    }
}