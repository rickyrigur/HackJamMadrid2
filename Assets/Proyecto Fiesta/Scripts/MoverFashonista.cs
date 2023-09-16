using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoverFashonista : MonoBehaviour
{
    public bool Activo;
    public float speed;
    public int IDPos;
    void Start()
    {
        Activo = false;
        IgnorarColisionFashonistas();
    }

    void Update()
    {
        Moverse();
    }

    public void Moverse()
    {
        if (!Activo)
            return;

        transform.position = Vector3.MoveTowards(transform.position, GestorAparicion.Instancia.puntos[IDPos].transform.position, speed * Time.deltaTime);
        
        if(transform.position == GestorAparicion.Instancia.puntos[GestorAparicion.Instancia.puntos.Length - 1].transform.position)
        {
            Activo = false;
        }
    }

    public void IgnorarColisionFashonistas()
    {
        for (int i = 0; i < GestorAparicion.Instancia.Fashonistas.Length ; i++)
        {
            Physics.IgnoreCollision(this.GetComponent<Collider>(), GestorAparicion.Instancia.Fashonistas[i].GetComponent<Collider>(), true);
        }        
    }
}
