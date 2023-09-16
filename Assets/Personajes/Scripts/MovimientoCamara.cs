using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public Camera Camara;
    public float sensibilidad;
    public float rotacionX, rotacionY;

    // Start is called before the first frame update
    void Start()
    {
        //Limitamos la vision del cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        CamaraFuncion();
    }

    public void CamaraFuncion()
    {
        //Hago una variable que va a estar recogiendo los datos de la rotación todo el tiempo.
        rotacionX -= SistemasPersonaje.Controles.RatonY * sensibilidad;
        //Clamp crea un límite entre dos valores de la variable que elijas.
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        Camara.transform.localRotation = Quaternion.Euler(rotacionX, 0, 0);

        rotacionY += SistemasPersonaje.Controles.RatonX * sensibilidad;

        transform.localRotation = Quaternion.Euler(0, rotacionY, 0);
    }
}
