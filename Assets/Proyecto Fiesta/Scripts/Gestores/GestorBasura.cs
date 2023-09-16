using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorBasura : MonoBehaviour
{
    public static GestorBasura Instancia;

    private void Awake()
    {
        Instancia = this;
    }

    public void DestruirAhora(GameObject Objeto)
    {
        Destroy(Objeto);
    }

    public void Limpiar(GameObject Objeto)
    {
        Collider ColiderTemporal = Objeto.GetComponent<Collider>();
        if (ColiderTemporal != null)
        {
            ColiderTemporal.enabled = false;
        }

        MeshRenderer renderer = Objeto.GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
        //Nos aseguramos de limpiar todos los hijos del objeto
        for (int i = 0; i < Objeto.transform.childCount; i++)
        {
            Limpiar(Objeto.transform.GetChild(i).gameObject);
        }
    }

    public IEnumerator DestruirEnXTiempo(GameObject Objeto, float Tiempo)
    {
        Limpiar(Objeto);

        yield return new WaitForSeconds(Tiempo);

        Destroy(Objeto);
    }
}
