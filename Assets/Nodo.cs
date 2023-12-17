
using System.Collections.Generic;
using UnityEngine;

public class Nodo
{
    //Array con las 9 casillas del puzzle
    int[] piezas = new int[9];

    
    //El constructor por defecto iniciará el nodo al resultado meta
    //(con los números del 0 al 8 colocados en orden)
    public Nodo()
    {
        for(int i = 0; i < 9; i++)
        {
            piezas[i] = i;
        }        
    }
    
    
    /// <summary>
    /// Desordena aleatoriamente el nodo
    /// </summary>
    public void Desordenar()
    {        
        int posicionAleatoria, temporal;

        for(int i = 0; i < 9; i++)
        {
            posicionAleatoria = Random.Range(0, 9);
            temporal = piezas[i];
            piezas[i] = piezas[posicionAleatoria];
            piezas[posicionAleatoria] = temporal;
        }       
    }

    
    /// <summary>
    /// Compara el nodo con otro nodo
    /// </summary>
    /// <param name="otroNodo"></param>
    /// <returns>true/false si los dos nodos son iguales/distintos</returns> <summary>    
    public bool EsIgualA(Nodo otroNodo)
    {
        for(int i = 0; i < 9; i++)
        {
            if(piezas[i] != otroNodo.piezas[i])
                return false;
        }

        return true;
    }

    /// <summary>
    /// Devuelve la posición del hueco en blanco en el nodo
    /// </summary>
    /// <returns></returns>
    private int PosicionHueco()
    {
        for(int i = 0; i < 9; i++)
        {
            if(piezas[i] == 0) return i;
        }
        return 0;
    }

    /// <summary>
    /// Evalúa nodos sucesores en base a los posibles movimientos del hueco
    /// </summary>
    /// <returns>Nodos sucesores</returns>
    public List<Nodo> ObtenerSucesores()
    {
        List<Nodo> sucesores = new List<Nodo>();

        return sucesores;
    }

    
    /// <summary>
    /// Representa el nodo
    /// </summary>
    /// <returns>un strign con la representación del nodo</returns> <summary>    
    public string Dibujar()
    {
        string nodoDibujado = "\n";
        for(int i = 0; i < 9; i++)
        {
            if((i + 1) % 3 == 0)            
                nodoDibujado += (piezas[i] + ",\n");
            else
                nodoDibujado += (piezas[i] + ",");            
        }
        nodoDibujado += "\n";

        return nodoDibujado;
    }
}
