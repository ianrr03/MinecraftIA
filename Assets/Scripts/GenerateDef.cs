using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDef : MonoBehaviour
{
    public GameObject cube;
    public int widht, height, large;
    public float detail;
    public int seed;
    void Start()
    {
        seed = Random.Range(10000, 900000);
        GenerateMap();
    }

    public void GenerateMap()
    {
        for (int x = 0; x < widht; x++)
        {
            for (int z = 0; z < large; z++)
            {

                height = (int)(Mathf.PerlinNoise((x / 2 + seed) / detail, (z / 2 + seed) / detail) * detail); //esto nos va a devolver un numero que el perlin noise lo va a transformar en una altura distinta
                //if (height < 3.0f)
                //{
                //    cube.GetComponent<Renderer>().material.color = Color.blue; // Parte de abajo, azul
                //}
                //else if (height < 6.0f)
                //{
                //    cube.GetComponent<Renderer>().material.color = new Color(0.6f, 0.3f, 0.0f); // Parte del medio, marrón
                //}
                //else
                //{
                //    cube.GetComponent<Renderer>().material.color = Color.green; // Parte de arriba, verde
                //}
                for (int y = 0; y < height; y++)
                {
                    Instantiate(cube, new Vector3(x, y, z), Quaternion.identity);
                   
                    
                }
            }
        }
    }
}
