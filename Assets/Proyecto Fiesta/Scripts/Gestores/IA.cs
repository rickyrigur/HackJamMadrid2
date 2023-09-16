using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
    NavMeshAgent Agente;
    public Animator Animator; // Animador del personaje

    [Header ("IA")]
    public GameObject Objetivo;
    public Vector3[] PuntosDeControl;
    public Vector3 DireccionActual;
    public SphereCollider colisionAtaque, colisionDeteccion;    

    [Header ("Testeo")]
    private int indice;
    public float temporizador;

    [Header("Propiedades")]   
    public float IdleMaximo;
    public bool rutaAleatoria;
    public float rangoAtaque, rangoDeteccion;
    public int daño;
    public float velocidadAndar, velocidadPerseguir;


    private void Awake()
    {
        Agente = GetComponent<NavMeshAgent>();        
    }

    // Start is called before the first frame update
    void Start()
    {
        colisionAtaque.radius = rangoAtaque;
        colisionDeteccion.radius = rangoDeteccion;
        //CambiarPuntosDeControl();
        Agente.speed = velocidadAndar; //Hacemos que la velocidad base se la de andar
        DireccionActual = PuntosDeControl[0];
    }

    // Update is called once per frame
    void Update()
    {
        Perseguir();
    }

    public void Perseguir()
    {
        Animator.SetFloat("Velocidad", Agente.velocity.magnitude);
        if(Objetivo != null)
        {
            DireccionActual = Objetivo.transform.position;
        }
        Agente.destination = DireccionActual;
        if (Agente.velocity.magnitude < 1f)
        {
            temporizador += Time.deltaTime;
        }
        
        ComprobarDistancia();
        ComprobarTiempoQuieto();
    }

    public void ComprobarTiempoQuieto()
    {
        if (temporizador >= IdleMaximo)
        {
            CambiarPuntosDeControl();
        }
    }

    public void ComprobarDistancia()
    {
        if(Vector3.Distance(transform.position, DireccionActual) <= 1 && Objetivo == null)
        {
            CambiarPuntosDeControl();
        }
    }

    public void CambiarPuntosDeControl()
    {
        Agente.speed = velocidadAndar;
        if (rutaAleatoria)
        {
            indice = Random.Range(0, PuntosDeControl.Length);
        }
        else
        {
            indice++;
            if (indice >= PuntosDeControl.Length)
                indice = 0;
        }

        DireccionActual = PuntosDeControl[indice];
        temporizador = 0;
    }    
    

    public void DefinirObjetivo(GameObject objetivo)
    {
        Agente.speed = velocidadPerseguir;
        Objetivo = objetivo;
    }

    public void Atacar(GameObject objetivo)
    {
        IDañable objetoDañable = objetivo.GetComponent<IDañable>();

        if(objetoDañable != null)
        {
            objetoDañable.ModificarVida(daño);
            Objetivo = null;
            CambiarPuntosDeControl();
        }
    }
}
