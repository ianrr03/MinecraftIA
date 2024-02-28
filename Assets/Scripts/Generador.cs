using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{

    public GameObject Grass;//agregado bus
    public GameObject dirt; //agregado bus
    public GameObject water;
    public int width, height, large;
    public int seed; //Semilla
    public float detail;
    
    public int minWaterDistance; //agregado bus
    public int maxWaterDistance; //agregado bus
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        for(int x = 0; x < width; x++)
        {
            int minHeight = height - 1; //agregado bus
            int maxHeight = height + 2; //agregado bus
            int minWaterSpawnDistance = height - minWaterDistance; //agregado bus
            int maxWaterSpawnDistance = height - maxWaterDistance; //agregado bus
            int totalWaterSpawnDistance = Random.Range(minWaterSpawnDistance, maxWaterSpawnDistance); //agregado bus
            for (int z = 0; z < large; z++)
            {
                height = (int)(Mathf.PerlinNoise((x/2+seed)/detail,(z/2+seed)/detail) * detail);
                for(int y = 0; y < height; y++)
                {
                    Instantiate(Grass, new Vector3(x, height, z), Quaternion.identity);
                }
                if (height < totalWaterSpawnDistance) //agregado bus
                {
                    Instantiate(water, new Vector3(x, height, z), Quaternion.identity); //agregado bus
                }
                else
                {
                    Instantiate(dirt, new Vector3(x, height, z), Quaternion.identity); //agregado bus
                }

                if (totalWaterSpawnDistance == height) //agregado bus
                {
                    Instantiate(water, new Vector3(x, height, z), Quaternion.identity); //agregado bus
                }
                else 
                {
                    Instantiate(Grass, new Vector3(x, height, z), Quaternion.identity); //agregado bus
                }

            }
        }


        //void spawnObj(GameObject obj, int x, int y, int z) //agregado bus
        //{
        //    obj = Instantiate(obj, new Vector3(x, y, z), Quaternion.identity);
        //    obj.transform.parent = this.transform;
        //}

        //forma simple
        //for(int x = 0; x < width; x++)
        //{
        //    for(int y = 0; y < height; y++)
        //    {
        //        for(int z = 0; z < large; z++)
        //        {
        //            Instantiate(cube, new Vector3(x, y, z),Quaternion.identity);
        //        }
        //    }
        //}


    }//GenerateMap

    
}//Generador
