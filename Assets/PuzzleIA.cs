using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzleIA : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cajaDibujo;

    
    private Nodo nodoActual = new Nodo();

    //El meta es un Nodo recién creado, sin desordenar
    private Nodo nodoMeta = new Nodo();

    //Lista de nodos sucesores del actual
    private List<Nodo> nodosSucesores = new List<Nodo>();

    //Lista de nodos abiertos, pendientes de comprobar;
    private List<Nodo> nodosAbiertos = new List<Nodo>();

    //Lista de nodos cerrados, ya comprobados
    private List<Nodo> nodosCerrados = new List<Nodo>();

    // Start is called before the first frame update
    void Start()
    {        
        cajaDibujo.text = nodoActual.Dibujar();        
    }

   
   public void Desordenar()
   {
        //Desordena evitando que por azar resulte el nodo ya ordenado
        bool continua = true;
        while(continua)
        {
            DesordenaNodo();
            if (!nodoActual.EsIgualA(nodoMeta))
                continua = false;
        }
        //Tras desordenar hay que reiniciar todas las listas        
        nodosSucesores.Clear();
        nodosAbiertos.Clear();
        nodosCerrados.Clear();
   }

    public void Resolver()
    {        
        nodosSucesores = nodoActual.ObtenerSucesores();
        
        /*Para comprobación interna desde la consola*******/
        /**/Debug.Log("Lista de nodos sucesores:\n");   /**/
        /**/foreach(Nodo n in nodosSucesores)           /**/        
        /**/    Debug.Log(n.Dibujar());                 /**/        
        /**************************************************/

        //Incluye los primeros sucesores en la lista de abiertos
        foreach(Nodo n in nodosSucesores)
            nodosAbiertos.Add(n);     

        //Pruebas internas
        MuestraListaAbiertos();   
        
        //El primer nodo actual se añade a la lista de cerrados
        nodosCerrados.Add(nodoActual);
        
        int numeroIntentos = 0;

        //while(nodosAbiertos.Count > 0)
        for(int i = 1; i <= 2; i++)
        {
            numeroIntentos++;
            Debug.Log("Intentos: " + numeroIntentos);
            //El primer nodo abierto se convierte en el actual
            nodoActual.CopiarEstado(nodosAbiertos[0]);
            //Lo sacamos de abiertos
            nodosAbiertos.RemoveAt(0);
            Debug.Log("Nodos abiertos: " + nodosAbiertos.Count + (nodosAbiertos.Count > 0));
            //Añadimos el nodo actual a cerrados
            nodosCerrados.Add(nodoActual);

            //Si el actual es el meta
            if(nodoActual.EsIgualA(nodoMeta))
            {
                Debug.Log("Obtenido el resultado en " + numeroIntentos + " intentos");
                cajaDibujo.text = nodoActual.Dibujar();
                break;
            }
            else
            {
                //Obtiene los sucesores del nodo actual
                nodosSucesores.Clear();
                nodosSucesores = nodoActual.ObtenerSucesores();
                //Añadimos a abiertos los sucesores que no estén ya en abiertos o cerrados
                //Primero obtenemos la posición de los sucesores a añadir
                List<int> posiciones = ObtieneIndicesNodosNuevos();
                if(posiciones.Count > 0)
                {
                    Debug.Log("Índices recibidos + " + posiciones.Count);
                    foreach(int posicion in posiciones)
                    {
                        Debug.Log("Insertando sucesor");
                        nodosAbiertos.Insert(0, nodosSucesores[posicion]);
                    }                    
                }                
            }            
        }
    }

    private List<int> ObtieneIndicesNodosNuevos()
    {
        List<int> indices = new List<int>();

       for(int s = 0; s < nodosSucesores.Count; s++)
       {
            //Debug.Log(nodosSucesores.Count + "  " + nodosAbiertos.Count);
            //Debug.Log(nodosSucesores[s].EsIgualA(nodosAbiertos[0]));
            
            //El nodo NO estará en alguna de las listas si la misma está vacía o tiene elementos pero no contiene al nodo
            bool estaEnAbiertos = Nodo.EstaEnLaLista(nodosSucesores[s], nodosAbiertos);
            bool estaEnCerrados = Nodo.EstaEnLaLista(nodosSucesores[s], nodosCerrados);

            if(!estaEnAbiertos && !estaEnCerrados)
                indices.Add(s);
            foreach(int indice in indices)
                Debug.Log(indice);
       }

        
        return indices;
    }


    private void DesordenaNodo()
    {        
        nodoActual.Desordenar();        
        cajaDibujo.text = nodoActual.Dibujar();       
    }


    //Métodos para pruebas internas
    private void MuestraListaAbiertos()
    {
        Debug.Log("LISTA DE NODOS ABIERTOS: " + nodosAbiertos.Count + "\n");
        for(int i = 0; i < nodosAbiertos.Count; i++)
        {
            Debug.Log(nodosAbiertos[i].Dibujar());
        }
    }
}
