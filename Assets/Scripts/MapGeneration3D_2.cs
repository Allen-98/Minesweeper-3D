using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration3D_2 : MonoBehaviour
{

    public GameObject map;
    public GameObject baseCube;
    public GameObject[,,] cubeList;


    [Header("Map Setting")]
    public int length = 5;
    public int width = 5;
    public int height = 5;

    [Header("Mine Setting")]
    //public GameObject mine;
    public int mineNumber = 5;


    [Header("Game Setting")]
    public GameObject gameOver;
    public GameObject gameWin;


    // Start is called before the first frame update
    void Start()
    {
        cubeList = new GameObject[width, height, length];
        GenerateMap();
    }


    public void GenerateMap()
    {
        if(gameWin.activeSelf || gameOver.activeSelf)
        {
            gameWin.SetActive(false);
            gameOver.SetActive(false);
        }

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
        cubeC1.GetComponent<BaseCube>().cubeCoordinates = new Vector3Int(x, y, z);
        cubeList[x, y, z] = cubeC1;
    }

    public void checkNeighbourCubes(Vector3Int cubeCoord)
    {

    }

    public void GenerateMines()
    {
        GenerateMap();

        for (int i = 0; i < mineNumber; i++)
        {
            RandomChoose();

        }

        MinesCount();

    }

    public void RandomChoose()
    {
        int x = Random.Range(0, width);
        int y = Random.Range(0, height);
        int z = Random.Range(0, length);

        GameObject o = cubeList[x, y, z];
        BaseCube bc = o.GetComponent<BaseCube>();

        if (bc.hasMine == false)
        {
            bc.hasMine = true;
            bc.cube.SetActive(false);
            bc.mine.SetActive(true);
        }
        else
        {
            RandomChoose();
        }
    }


    public void MinesCount()
    {
        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                for (int l = 0; l < length; l++)
                {
                    GameObject cubeC2 = cubeList[w, h, l];
                    
                    for (int x = w - 1; x <= w + 1; x++)
                    {
                        if (x >= 0 && x < width)
                        {
                            for (int y = h - 1; y <= h + 1; y++)
                            {
                                if (y >= 0 && y < height)
                                {
                                    for (int z = l - 1; z <= l + 1; z++)
                                    {
                                        if (z >= 0 && z < length)
                                        {
                                            if (cubeList[x, y, z] != null)
                                            {
                                                if (cubeList[x, y, z].GetComponent<BaseCube>().hasMine)
                                                {
                                                    cubeC2.GetComponent<BaseCube>().neighbourMines += 1;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    cubeC2.GetComponent<BaseCube>().tmp.SetText(cubeC2.GetComponent<BaseCube>().neighbourMines.ToString());
                }
            }
        }
    }


    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);

    }

    public void GameWin()
    {
        Time.timeScale = 0f;
        gameWin.SetActive(true);
    }


}
