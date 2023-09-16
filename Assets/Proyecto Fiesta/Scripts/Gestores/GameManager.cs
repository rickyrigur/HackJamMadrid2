using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int CantidadFashonistas;
    public int Posiciones;
    public int CantidadRondas;
    public int ContadorRondas;
    public bool FinRonda;

    // Start is called before the first frame update
    void Start()
    {
        ContadorRondas = 1;
        GestionarRondas();              
    }

    // Update is called once per frame
    void Update()
    {
        if(FinRonda)
        {
            FinalRonda();
            GestionarRondas();
        }
    }

    public void PosicionarFashonista(int posicion, int CantidadFashonista)
    {
        GestorAparicion.Instancia.Aparecer(posicion, CantidadFashonista);
    }

    public void GestionarRondas()
    {
        PosicionarFashonista(ContadorRondas, CantidadFashonistas);

        ContadorRondas++;
        if (CantidadFashonistas < GestorAparicion.Instancia.Fashonistas.Length)
        {
            CantidadFashonistas++;
        }
        print("Contador Rondas: " + ContadorRondas);
        print("Cantidad Fashonistas: " + CantidadFashonistas);
    }

    public void FinalRonda()
    {
        for (int i = 0; i < CantidadFashonistas; i++)
        {
            MoverFashonista moverFashonista = GestorAparicion.Instancia.Fashonistas[i].GetComponent<MoverFashonista>();
            moverFashonista.IDPos = GestorAparicion.Instancia.puntos.Length - 1;
        }        
        FinRonda = false;
    }
}
