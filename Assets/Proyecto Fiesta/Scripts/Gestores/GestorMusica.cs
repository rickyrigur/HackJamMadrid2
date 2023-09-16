using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorMusica : MonoBehaviour
{
    public static GestorMusica Instancia;

    void Awake()
    {
        Instancia = this;
    }

    public static void PonerMusica(AudioClip ClipAudio, AudioSource Reproductor, bool DebeRepetirse)
    {
        Reproductor.clip = ClipAudio;
        Reproductor.loop = DebeRepetirse;
        Reproductor.Play();
    }

}
