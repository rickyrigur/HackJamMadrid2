using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GestorAparicion : MonoBehaviour
{
    public static GestorAparicion Instancia;
    public float Temporizador;

    public GameObject[] Fashonistas;
    public GameObject[] puntos;
    public List<Collider> ObjetosAIgnorarFashonista;


    private void Awake()
    {
        Instancia = this;
    }

    void Start()
    {
        for (int i = 0; i < Fashonistas.Length; i++)
        {
            ObjetosAIgnorarFashonista.Add(Fashonistas[i].gameObject.GetComponent<Collider>());
        }
        print(ObjetosAIgnorarFashonista.Count);
        //Aparecer(0);
    }

    public void Aparecer(int ID, int CantidadFashonista)
    {
        //GameObject FashonistaNuevo = Instantiate(Fashonistas[0]);
        for (int i = 0; i <= CantidadFashonista; i++)
        {
            Fashonistas[i].transform.position = puntos[0].transform.position + new Vector3(0,0,i);
            MoverPersonaje(i + 1, i);
        }        
    }

    public void MoverPersonaje(int ID, int NumFashonista)
    {
        MoverFashonista moverFashonista =  Fashonistas[NumFashonista].GetComponent<MoverFashonista>();
        if(moverFashonista != null)
        {
            moverFashonista.IDPos = ID;
            moverFashonista.Activo = true;
        }
    }

    public void SistemaTiempo()
    {
        Temporizador += Time.deltaTime;
    }

    public void Reaparicion(int Fashonista)
    {
        //int ID = 0;
        
        //for (int i = 1; i < puntos.Length; i++)
        //{
            
        //}
        //MoverPersonaje(ID);
    }    
}
