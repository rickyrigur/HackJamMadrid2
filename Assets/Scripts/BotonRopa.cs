using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonRopa : MonoBehaviour
{
    public int ID;
	public Ropa TipoRopa;
	public GameObject PantallaArmario;

	public void CambiarRopa()
	{
		print("ID" + ID);
		print((int)TipoRopa);
        ICambioRopa CAmbioRopa = PantallaArmario.GetComponent<ICambioRopa>();
        if (CAmbioRopa != null)
        {
            CAmbioRopa.CambiarRopa(ID, (int)TipoRopa);
        }
    }

	public enum Ropa
	{
		Hat = 1,
		Shirt = 2,
		Pant = 3,
		Shoe = 4
	}
}
