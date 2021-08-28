using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration3D : MonoBehaviour
{
    public GameObject map;
    public GameObject normalCube;
    public GameObject cornerCube;
    public GameObject edgeCube;

    [Header("Map Setting")]
    public int length = 5;
    public int width = 5;
    public int height = 5;

    [Header("Mine Setting")]
    public GameObject mine;
    public int mineNumber = 5;


    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
        //GenerateSurface();
    }


    public void GenerateMap()
    {

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                for (int k = 0; k < height; k++)
                {

                    CheckCube(i, k, j);

                }
            }
        }

    }

    public void GenerateSurface()
    {
        float offset = 0.5f;

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Vector3 pos = new Vector3(i, j, -offset);
                GameObject cube = Instantiate(mine, pos, Quaternion.identity);
                cube.transform.parent = map.transform;
                cube.name = "Surface pad: " + i + "," + j; 
            }
        }
    }


    public void CheckCube(int x, int y, int z)
    {
        // Bottom level & Top level
        if (y == 0 || y == height - 1)
        {
            // Corner Cube
            if (x == 0 || x == length - 1)
            {
                if (z == 0 || z == width - 1)
                {
                    Vector3 posC1 = new Vector3(x, y, z);
                    GameObject cubeC1 = Instantiate(cornerCube, posC1, Quaternion.identity);
                    cubeC1.transform.parent = map.transform;
                    cubeC1.name = x + "," + y + "," + z;
                }

            }

            // Edge Cube
            if (x == 0 || x == length - 1)
            {
                if (z > 0 && z < width - 1)
                {
                    Vector3 posC1 = new Vector3(x, y, z);
                    GameObject cubeC1 = Instantiate(edgeCube, posC1, Quaternion.identity);
                    cubeC1.transform.parent = map.transform;
                    cubeC1.name = x + "," + y + "," + z;
                }
            } 
            else if (z == 0 || z == width - 1)
            {
                if (x > 0 && x < length - 1)
                {
                    Vector3 posC1 = new Vector3(x, y, z);
                    GameObject cubeC1 = Instantiate(edgeCube, posC1, Quaternion.identity);
                    cubeC1.transform.parent = map.transform;
                    cubeC1.name = x + "," + y + "," + z;
                }
            }


            // Normal Cube
            else
            {
                Vector3 posC1 = new Vector3(x, y, z);
                GameObject cubeC1 = Instantiate(normalCube, posC1, Quaternion.identity);
                cubeC1.transform.parent = map.transform;
                cubeC1.name = x + "," + y + "," + z;
            }



        }

        // Middle level
        if (y > 0 && y < height - 1)
        {
            // Edge Cube
            if (x == 0 || x == length - 1)
            {
                if (z == 0 || z == width - 1)
                {
                    Vector3 posC1 = new Vector3(x, y, z);
                    GameObject cubeC1 = Instantiate(edgeCube, posC1, Quaternion.identity);
                    cubeC1.transform.parent = map.transform;
                    cubeC1.name = x + "," + y + "," + z;
                }
                else
                {
                    Vector3 posC1 = new Vector3(x, y, z);
                    GameObject cubeC1 = Instantiate(normalCube, posC1, Quaternion.identity);
                    cubeC1.transform.parent = map.transform;
                    cubeC1.name = x + "," + y + "," + z;
                }

            }

            // Normal Cube
            else
            {
                Vector3 posC1 = new Vector3(x, y, z);
                GameObject cubeC1 = Instantiate(normalCube, posC1, Quaternion.identity);
                cubeC1.transform.parent = map.transform;
                cubeC1.name = x + "," + y + "," + z;
            }
        }

    }


}
