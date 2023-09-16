
//La interfaz se basa en que puede hace, en este caso, se puede activar
using UnityEngine;

public interface IActivable
{
    //Contiene una función vacía que se usara mas adelante
    public void Activar();

}

public interface IColisionable
{
    public void AlColisionar();
}

public interface ITieneDueño
{
    //public void DefinirDueño(Boton dueño);
}

public interface IDañable
{
    public void ModificarVida(float cantidad);
}

public interface IConsumible
{
    public void AlConsumir(GameObject Consumidos);
}

public interface ITieneMonedas
{
    public void ModificarMonedas(int Cantidad);
}

public interface IDisparar
{
    public void LimpiarLista(Collider Objeto);
}

public interface IPuedeMorir
{
    public void AlMorir();
}

public interface ICambioRopa
{
    public void CambiarRopa(int IDRopa, int TipoRopa);
}
