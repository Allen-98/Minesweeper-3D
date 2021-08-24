using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{

    public GameObject map;
    public GameObject defaultCube;

    [Header("Map Setting")]
    public int row=5;
    public int column=5;



    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateMap()
    {

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                Vector3 pos = new Vector3(i, j, 0);
                GameObject cube = Instantiate(defaultCube, pos, Quaternion.identity);
                cube.transform.parent = map.transform;
            }
        }

    }


}
