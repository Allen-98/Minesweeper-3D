using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration3D_2 : MonoBehaviour
{

    public GameObject map;
    public GameObject baseCube;
    private GameObject[,,] cubeList;


    [Header("Map Setting")]
    public int length = 5;
    public int width = 5;
    public int height = 5;

    [Header("Mine Setting")]
    //public GameObject mine;
    public int mineNumber = 5;





    // Start is called before the first frame update
    void Start()
    {
        cubeList = new GameObject[width, height, length];
        GenerateMap();
    }


    public void GenerateMap()
    {
        if (map.GetComponentsInChildren<Transform>(true).Length <= 1)
        {
            Debug.Log("No children");
        }
        else
        {
            int childCount = map.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Destroy(map.transform.GetChild(i).gameObject);
            }
        }

        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                for (int l = 0; l < length; l++)
                {
                    CheckCube(w, h, l);
                }
            }
        }

    }


    public void CheckCube(int x, int y, int z)
    {
        Vector3 posC1 = new Vector3(x, y, z);
        GameObject cubeC1 = Instantiate(baseCube, posC1, Quaternion.identity);
        cubeC1.transform.parent = map.transform;
        cubeC1.name = x + "," + y + "," + z;
        cubeList[x, y, z] = cubeC1;
    }

    public void GenerateMines()
    {
        GenerateMap();

        for (int i = 0; i <= mineNumber; i++)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);
            int z = Random.Range(0, length);

            GameObject o = cubeList[x, y, z];

            o.transform.GetChild(0).gameObject.SetActive(false);
            o.transform.GetChild(1).gameObject.SetActive(true);

        }
    }




}
