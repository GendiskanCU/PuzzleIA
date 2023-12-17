using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeArrays : MonoBehaviour
{

    public float[] floatVector;

    public int[] intVector;

    public GameObject[] gameObjectVector;


    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RandomizeArray(floatVector);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RandomizeArray(intVector);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            RandomizeArray(gameObjectVector);
        }
    }

    public void RandomizeArray<T>(T[] array)
    {

        int n = array.Length;
        int randomValue;
        T temp;
        for (int i = n-1; i >= 0; i--)
        {
            randomValue = Random.Range(0,n);
            temp = array[randomValue];
            array[randomValue] = array[i];
            array[i] = temp;
        }

    }

    public void RandomizeArray<T>(T[] array, int k)
    {
        for (int j = 0; j < k; j++)
        {
            RandomizeArray(array);
        }

    }


}
