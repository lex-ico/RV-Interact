using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Motores multiplataforma II
/// Script para cambiar el objeto que se lleva en la mano, requiere que la mano en cuesti�n tenga un componente showByAction
/// Se tiene que asignar a la misma mano
/// Puede llamarse desde un bot�n, por ejemplo
/// </summary>
public class cambiaElemento : MonoBehaviour
{
    public void hacerCambio(GameObject go)
    {
        this.GetComponent<showByAction>().Activar(false);
        this.GetComponent<showByAction>().listaObjetosMostrar.Clear();
        this.GetComponent<showByAction>().listaObjetosMostrar.Add(go);
    }
}
