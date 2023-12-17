using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzleIA : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cajaDibujo;

    
    private Nodo nodoActual = new Nodo();

    //El meta es un Nodo recién creado, sin desordenar
    private Nodo nodoMeta = new Nodo();

    // Start is called before the first frame update
    void Start()
    {        
        cajaDibujo.text = nodoActual.Dibujar();        
    }

   
   public void Desordenar()
   {
        DesordenaNodo();
   }

    public void Resolver()
    {        
        
    }


    private void DesordenaNodo()
    {        
        nodoActual.Desordenar();        
        cajaDibujo.text = nodoActual.Dibujar();       
    }
}
