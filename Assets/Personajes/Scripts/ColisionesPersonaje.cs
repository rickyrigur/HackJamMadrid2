using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionesPersonajes : MonoBehaviour
{
    private void OnCollisionEnter(Collision colision)
    {
        IColisionable colisionable = colision.gameObject.GetComponent<IColisionable>();
        if(colisionable != null)
        {
            colisionable.AlColisionar();
        }

    }

    private void OnCollisionExit(Collision colision)
    {

        
    }

    private void OnTriggerEnter(Collider colision)
    {
        IA Enemigo = colision.gameObject.GetComponent<IA>();
        //Si tiene IA
        if (Enemigo != null)
        {
            //Llamamos a definir objetivo si colisionamos con rango deteccion
            if(colision == Enemigo.colisionDeteccion)
            {
                Enemigo.DefinirObjetivo(gameObject);
            }
            //Llamamos a atacar si colisionamos con tango ataque
            if (colision == Enemigo.colisionAtaque)
            {
                Enemigo.Atacar(gameObject);
            }            
        }

        FinDeMapa Fin = colision.gameObject.GetComponent<FinDeMapa>();
        if(Fin != null)
        {
            Fin.AlSalirse();
            SistemasPersonaje.EstadisticasPersonaje.ModificarVida(10);
        }

        IConsumible Consumible = colision.gameObject.GetComponent<IConsumible>();
        if(Consumible != null)
        {
            Consumible.AlConsumir(gameObject);
        }

        IColisionable colisionable = colision.gameObject.GetComponent<IColisionable>();
        if (colisionable != null)
        {
            colisionable.AlColisionar();
        }
    }
}
