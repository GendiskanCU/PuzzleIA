
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
    /// Copia el estado del nodo original
    /// </summary>
    /// <param name="nodoOriginal"></param>
    public void CopiarEstado(Nodo nodoOriginal)
    {
        for(int i = 0; i < 9; i++)
            {
                piezas[i] = nodoOriginal.piezas[i];
            }
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
        //Lista de sucesores a obtener y devolver
        List<Nodo> sucesores = new List<Nodo>();

        //Listas nombradas con la dirección a la que se puede mover el hueco
        //si actualmente está en alguna de las posiciones de cada lista
        List<int> HaciaDerecha = new List<int> {0, 1, 3, 4, 6, 7};
        List<int> HaciaIzquierda = new List<int> {1, 2, 4, 5, 7, 8};
        List<int> HaciaArriba = new List<int> {3, 4, 5, 6, 7, 8};
        List<int> HaciaAbajo = new List<int> {0, 1, 2, 3, 4, 5};        
        

        //Obtiene las posibles nuevas posiciones del hueco y nodos resultantes.
        //Si el hueco actualmente está en la posición de alguna de las listas
        //se calcula el nodo resultante del movimiento a la dirección adecuada
        //y se añade a la lista de nodos sucesores
        int posicionActual = PosicionHueco();
        int nuevaPosicionHueco;

        if(HaciaDerecha.Contains(posicionActual))
        {
            nuevaPosicionHueco = posicionActual + 1;
            sucesores.Add(Sucesor(posicionActual, nuevaPosicionHueco));
            
            Debug.Log("\nNodo sucesor añadido:\n" + Sucesor(posicionActual, nuevaPosicionHueco).Dibujar());
        }

        if(HaciaIzquierda.Contains(posicionActual))
        {
            nuevaPosicionHueco = posicionActual - 1;
            sucesores.Add(Sucesor(posicionActual, nuevaPosicionHueco));
            
            Debug.Log("\nNodo sucesor añadido:\n" + Sucesor(posicionActual, nuevaPosicionHueco).Dibujar());
        }

        if(HaciaArriba.Contains(posicionActual))
        {
            nuevaPosicionHueco = posicionActual - 3;
            sucesores.Add(Sucesor(posicionActual, nuevaPosicionHueco));
            
            Debug.Log("\nNodo sucesor añadido:\n" + Sucesor(posicionActual, nuevaPosicionHueco).Dibujar());
        }

        if(HaciaAbajo.Contains(posicionActual))
        {
            nuevaPosicionHueco = posicionActual + 3;
            sucesores.Add(Sucesor(posicionActual, nuevaPosicionHueco));
            
            Debug.Log("\nNodo sucesor añadido:\n" + Sucesor(posicionActual, nuevaPosicionHueco).Dibujar());
        }

        
        return sucesores;
    }

    private Nodo Sucesor(int posActual, int posNueva)
    {
        //Crea un nuevo nodo temporal para trabajar con él sin modificar el original
        Nodo nodoTemporal = new Nodo();
        //Copia el estado del nodo original al temporal
        nodoTemporal.CopiarEstado(this);

        int temporal = nodoTemporal.piezas[posNueva];
        //Coloca el hueco en su nueva posición
        nodoTemporal.piezas[posNueva] = 0;
        //Se intercambia por el valor que había en ella
        nodoTemporal.piezas[posActual] = temporal;

        return nodoTemporal;       
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
