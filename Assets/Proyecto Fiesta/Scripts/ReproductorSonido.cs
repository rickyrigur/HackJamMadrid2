using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class ReproductorSonido : MonoBehaviour
{
    public AudioClip ClipAudio;
    public bool PonerAlEmpezar;
    public bool DebeRepetirse;
    
    private AudioSource Reproductor;


    private void Awake()
    {
        Reproductor = GetComponent<AudioSource>();
    }

    void Start()
    {
        if(PonerAlEmpezar)
        {
            PonerClip();
        }
    }

    public void PonerClip()
    {
        GestorMusica.PonerMusica(ClipAudio, Reproductor, DebeRepetirse);
    }
}
