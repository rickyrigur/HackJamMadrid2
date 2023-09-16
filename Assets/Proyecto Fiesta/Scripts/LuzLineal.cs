using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LuzLineal : MonoBehaviour
{
    public Light luz;
    Material material;
    public float Intensidad;
    public float LimiteIntensidad;
    Color ColorLuz;
    public Color colorApagado;
    //public Color colorEncendido;
    //float red;
    //float green;
    //float blue;
    //float alpha;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        luz.intensity = 0;
        Intensidad = 0f;
        //material.SetColor("_EmissionColor", colorApagado);
        ColorLuz = luz.color;
        ActualizarLuz();
    }

    private void OnMouseOver()
    {
        ActualizarLuz();
        //ActualizarColorEmision();
    }

    public void ActualizarLuz()
    {
        if (Intensidad >= LimiteIntensidad)
            return;

        Intensidad += 0.1f * Time.deltaTime;
        material.color = ColorLuz * Intensidad * 2;
        luz.intensity = Intensidad;
        material.SetColor("_EmissionColor", material.color);
    }


    //public void ActualizarColorEmision()
    //{
    //    if (red <= colorEncendido.r)
    //        red += Time.deltaTime;
    //    if (green <= colorEncendido.g)
    //        green += Time.deltaTime;
    //    if (blue <= colorEncendido.b)
    //        blue += Time.deltaTime;
    //    if (alpha <= colorEncendido.a)
    //        alpha += Time.deltaTime;

    //    material.SetColor("_EmissionColor", new Color(red,green,blue,alpha));
    //}

}
