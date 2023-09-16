using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GestorDecals : MonoBehaviour
{
    public static GestorDecals Instancia;
    public GameObject Decal;
    public List<GameObject> Decals;
    public int LimiteDecals;

    void Awake()
    {
        Instancia = this;
    }

    public void CrearDecal(Vector3 Origen, Vector3 Destino, GameObject ObjetoChocado, Color ColorDecal)
    {
        //Guarda datos de los objetos con los que chocamos
        RaycastHit[] Datos;

        //Un rayo es una linea con un punto de origen y una direccion Ray Rayo = new Ray(Origen, Destino)
        Ray Rayo = new Ray(Origen, Destino - Origen); 

        //Calculamos la distancia que debe tener el rayo
        float Distancia = Vector3.Distance(Origen, Destino)+0.1f;

        //Raycastall(Origen,Direccion,Distancia)
        Datos = Physics.RaycastAll(Rayo.origin, Rayo.direction, Distancia);

        for(int i = 0; i < Datos.Length; i++)
        {
            if (ObjetoChocado == Datos[i].transform.gameObject)
            {
                Vector3 Posicion = Datos[i].point + Datos[i].normal * 0.0001f;
                Quaternion Rotacion = Quaternion.FromToRotation(Vector3.back, Datos[i].normal);
                GameObject NuevoDecal = Instantiate(Decal, Posicion, Rotacion);

                NuevoDecal.GetComponent<Renderer>().material.color = ColorDecal;
                NuevoDecal.GetComponent<Renderer>().material.SetColor("_EmissionColor", ColorDecal * 2);
                NuevoDecal.transform.GetChild(0).GetComponent<Light>().color = ColorDecal;

                Debug.DrawRay(Rayo.origin, Rayo.direction * Datos[i].distance, Color.white, 10);
                
                //Esto hará que el decal siga los objetos si estos se mueven en vez de que el decal quede en el aire si el bojeto se mueve
                NuevoDecal.transform.parent = Datos[i].transform;

                Decals.Add(NuevoDecal);
                if (Decals.Count >= LimiteDecals)
                {
                    if (Decals[0] == null)
                    {
                        Decals.RemoveAt(0);
                    }
                    Destroy(Decals[0]);
                }

                break;
            }
        }
    }
}
